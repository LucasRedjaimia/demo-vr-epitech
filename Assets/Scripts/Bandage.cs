using UnityEngine;

public class Bandage : MonoBehaviour
{
    public int healAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
        {
            gameManager.ApplyBandage(healAmount);
            Destroy(gameObject);
        }
    }
}