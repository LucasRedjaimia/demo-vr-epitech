using UnityEngine;

public class InventoryFollower : MonoBehaviour
{
    public Transform anchor; // à assigner dans l’inspecteur
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // désactive la gravité si nécessaire
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = anchor.position;
        Quaternion targetRotation = anchor.rotation;

        rb.MovePosition(targetPosition);
        rb.MoveRotation(targetRotation);
    }
}
