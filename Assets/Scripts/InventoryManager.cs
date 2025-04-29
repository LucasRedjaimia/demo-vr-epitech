using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public int itemCount = 0;
    public int totalItems = 5;

    public TextMeshPro counterText;

    void Start()
    {
        UpdateUI();
    }

    public void AddItem(int amount)
    {
        itemCount += amount;
        itemCount = Mathf.Clamp(itemCount, 0, totalItems);
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (counterText != null)
        {
            counterText.text = itemCount + " / " + totalItems;
        }
    }
}
