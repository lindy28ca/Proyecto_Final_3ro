using UnityEngine;

public class CamaraController : MonoBehaviour
{
    #region Variables

    [Header("Raycast")]
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float distance = 5f;

    private RaycastHit hit;
    private ObjectInteractive objectInteractive;
    private ResaltadorInteractuable resaltadorActual;
    private bool isInteractive = false;

    #endregion

    #region Unity Methods

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance, layerMask))
        {
            ObjectInteractive nuevoObjeto = hit.collider.GetComponent<ObjectInteractive>();
            ResaltadorInteractuable nuevoResaltador = hit.collider.GetComponent<ResaltadorInteractuable>();

            if (nuevoObjeto != null && nuevoObjeto != objectInteractive)
            {
                if (objectInteractive != null)
                    objectInteractive.DesactiveInput();
                if (resaltadorActual != null)
                    resaltadorActual.DesactivarResaltado();

                objectInteractive = nuevoObjeto;
                resaltadorActual = nuevoResaltador;

                objectInteractive.ActiveInput();
                if (resaltadorActual != null)
                    resaltadorActual.ActivarResaltado();

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

            if (resaltadorActual != null)
            {
                resaltadorActual.DesactivarResaltado();
                resaltadorActual = null;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && objectInteractive != null)
        {
            DesaparecerConFeedback desaparece = objectInteractive.GetComponent<DesaparecerConFeedback>();
            if (desaparece != null)
            {
                desaparece.Desaparecer();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * distance);
    }

    #endregion
}
