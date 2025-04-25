using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public int itemValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        InventoryManager inventory = other.GetComponent<InventoryManager>();
        if (inventory != null)
        {
            inventory.AddItem(itemValue);
            Destroy(gameObject); // Supprime l’objet ramassé
        }
    }
}
