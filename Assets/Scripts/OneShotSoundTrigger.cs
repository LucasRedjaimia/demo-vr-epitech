using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotSoundTrigger : MonoBehaviour
{
    private bool hasPlayed = false;
    public AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Player"))
        {
            Debug.Log("Détection du joueur OK → je joue le son !");
            audioSource.Play();
            hasPlayed = true;
        }
    }
}
