using UnityEngine;

public class CamaraController : MonoBehaviour
{
    [Header("Raycast")]
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float distance;

    private void FixedUpdate()
    {
        Physics.Raycast(transform.position, transform.forward ,distance, layerMask);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * distance);
    }
}
