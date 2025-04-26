using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Flashlight2 : MonoBehaviour
{
    public Material lens;
    private Light _light;
    private AudioSource _audioSource;
    private XRGrabInteractable _grabInteractable;

    private bool isOn = false; // On ajoute un état interne

    void Start()
    {
        _light = GetComponentInChildren<Light>();
        _audioSource = GetComponent<AudioSource>();
        _grabInteractable = GetComponent<XRGrabInteractable>();

        _grabInteractable.activated.AddListener(OnActivate);
    }

    private void OnActivate(ActivateEventArgs args)
    {
        // Inverse l'état de la lampe à chaque activation
        isOn = !isOn;
        if (isOn)
            LightOn();
        else
            LightOff();
    }

    public void LightOn()
    {
        _audioSource.Play();
        lens.EnableKeyword("_EMISSION");
        _light.enabled = true;
    }

    public void LightOff()
    {
        _audioSource.Play();
        lens.DisableKeyword("_EMISSION");
        _light.enabled = false;
    }
}
