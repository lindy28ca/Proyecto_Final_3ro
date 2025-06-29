using UnityEngine;
using System.Collections;

public class DoorController : ObjectInteractive
{
    [SerializeField] private Vector3 rotation;
    [SerializeField] private string nombreObjetoRequerido = "Pinza"; // El nombre exacto del objeto en ItemsInformation

    private Quaternion rotacionInicial;
    private Quaternion rotacionFinal;
    private bool abierta;

    private void Awake()
    {
        rotacionInicial = transform.rotation;
        rotacionFinal = Quaternion.Euler(rotation);
    }

    protected override void Interaccion()
    {
        if (!abierta)
        {
            if (GameManager.Instance != null && GameManager.Instance.TieneObjeto(nombreObjetoRequerido))
            {
                abierta = true;
                StartCoroutine(AnimationDoor(3f));
            }
            else
            {
                Debug.Log("No tienes el objeto necesario: " + nombreObjetoRequerido);
            }
        }
        else
        {
            abierta = false;
            StartCoroutine(AnimationDoor(3f));
        }
    }

    private void Update()
    {
        Quaternion destino = abierta ? rotacionFinal : rotacionInicial;
        transform.rotation = Quaternion.Slerp(transform.rotation, destino, 5 * Time.deltaTime);
    }

    private IEnumerator AnimationDoor(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
    }
}
