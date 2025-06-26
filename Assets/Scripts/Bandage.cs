using UnityEngine;

public class Bandage : MonoBehaviour
{
    public int healAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        InventoryManager inventory = other.GetComponent<InventoryManager>();

        if (inventory != null)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();

            if (gameManager != null)
            {
                gameManager.ApplyBandage(healAmount);
                Destroy(gameObject);
            }
        }
    }
}