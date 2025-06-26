using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    [Header("Lampe à recharger (Light Component)")]
    public Light targetLight;

    [Header("Capacité max de la lampe")]
    public float maxIntensity = 1.5f;
    public float minIntensity = 0f;

    [Header("Lamp Charge Settings")]
    public float maxCharge = 100f;
    public float currentCharge = 100f;
    public float drainDuration = 10f;
    public float drainRate = 20f;

    void Awake()
    {
        if (targetLight == null)
        {
            Debug.LogError("Aucune lampe assignée à LightBehaviour !");
            return;
        }

        drainRate = maxCharge / drainDuration;
        Debug.Log("Drain rate calculé : " + drainRate);
        UpdateLightIntensity();
    }

    void Update()
    {
        if (currentCharge > 0f)
        {
            currentCharge -= drainRate * Time.deltaTime;
            currentCharge = Mathf.Max(currentCharge, 0f);
            UpdateLightIntensity();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger détecté avec : " + other.name + " | Tag : " + other.tag + " | IsTrigger : " + other.isTrigger);

        if (!other.CompareTag("Batterie"))
        {
            Debug.Log("Objet entrant n'est pas une batterie, on ignore.");
            return;
        }

        Debug.Log("→ C'est bien une batterie !");

        BatteryPickup pickup = other.GetComponent<BatteryPickup>();
        if (pickup == null)
        {
            Debug.LogWarning("⚠ Batterie sans BatteryPickup.cs !");
            return;
        }

        Debug.Log("Recharge lampe de : " + pickup.energy);
        currentCharge += pickup.energy;
        currentCharge = Mathf.Min(currentCharge, maxCharge);
        UpdateLightIntensity();

        Debug.Log("Charge actuelle de la lampe après recharge : " + currentCharge);

        Destroy(other.gameObject);
        Debug.Log("Batterie détruite après recharge.");
    }

    private void UpdateLightIntensity()
    {
        if (targetLight == null) return;

        float ratio = currentCharge / maxCharge;
        targetLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, ratio);
    }
}
