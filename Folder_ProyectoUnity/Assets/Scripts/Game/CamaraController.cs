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
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance, layerMask))
        {
            ObjectInteractive nuevoObjeto = hit.collider.GetComponent<ObjectInteractive>();

            if (nuevoObjeto != null && nuevoObjeto != objectInteractive)
            {
                if (objectInteractive != null)
                {
                    objectInteractive.DesactiveInput(); // Desactiva el anterior
                }

                objectInteractive = nuevoObjeto;
                objectInteractive.ActiveInput(); // Activa el nuevo
                isInteractive = true;
            }
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
