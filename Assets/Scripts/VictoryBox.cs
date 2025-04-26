using UnityEngine;

public class VictoryBox : MonoBehaviour
{
    public Material activeMaterial;
    private Material originalMaterial;
    private MeshRenderer meshRenderer;
    private bool isActive = false;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            originalMaterial = meshRenderer.material;
        }
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        isActive = true;
        if (meshRenderer != null && activeMaterial != null)
        {
            meshRenderer.material = activeMaterial;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActive)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.PlayerReachedVictoryBox();
            }
        }
    }
}