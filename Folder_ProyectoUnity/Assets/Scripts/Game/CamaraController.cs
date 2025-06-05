using UnityEngine;

public class CamaraController : MonoBehaviour
{
    [Header("Raycast")]
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float distance;
    private RaycastHit hit;
    private ObjectInteractive objectInteractive;
    private bool isInteractive = false;

    private void FixedUpdate()
    {
        Physics.Raycast(transform.position, transform.forward, out hit, distance, layerMask);

        if (hit.collider != null && !isInteractive)
        {
            objectInteractive = hit.collider.GetComponent<ObjectInteractive>();
            objectInteractive.ActiveInput();
            isInteractive = true;
        }
        else
        {
            if (objectInteractive != null)
            {
                objectInteractive.DesactiveInput();
                objectInteractive = null;
                isInteractive = false;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * distance);
    }
}
