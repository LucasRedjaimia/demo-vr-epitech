using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestAudioManager : MonoBehaviour
{
    [Header("Sons d’ambiance constants")]
    public AudioSource[] constantAmbienceSources;

    [Header("Clips aléatoires d’ambiance")]
    public AudioClip[] randomClips;

    [Header("Temps entre sons aléatoires (secondes)")]
    public float minDelay = 10f;
    public float maxDelay = 30f;

    private AudioSource randomAudioSource;

    void Start()
    {
        // Lance tous les sons constants
        foreach (AudioSource src in constantAmbienceSources)
        {
            if (!src.isPlaying)
                src.Play();
        }

        // Crée un audio source pour les sons aléatoires
        randomAudioSource = gameObject.AddComponent<AudioSource>();
        randomAudioSource.spatialBlend = 0.5f; // 2D/3D mix

        StartCoroutine(PlayRandomSounds());
    }

    IEnumerator PlayRandomSounds()
    {
        while (true)
        {
            float waitTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(waitTime);

            if (randomClips.Length > 0)
            {
                AudioClip clip = randomClips[Random.Range(0, randomClips.Length)];
                randomAudioSource.PlayOneShot(clip);
            }
        }
    }
}
