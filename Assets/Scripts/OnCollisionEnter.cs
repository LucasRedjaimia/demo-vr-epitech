using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundOnCollision : MonoBehaviour
{
    public AudioClip soundToPlay;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (soundToPlay != null && audioSource != null)
        {
            audioSource.PlayOneShot(soundToPlay);
        }
    }
}