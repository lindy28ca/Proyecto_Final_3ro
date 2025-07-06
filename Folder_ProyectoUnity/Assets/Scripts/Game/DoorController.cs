
using UnityEngine;
using System.Collections;

public class DoorController : ObjectInteractive
{
    [SerializeField] private Vector3 rotation;
    [SerializeField] private string nombreObjetoRequerido = "Pinza";

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
            if (GameManager.Instance != null && GameManager.Instance.PinzaEnMano(nombreObjetoRequerido))
            {
                abierta = true;
                StartCoroutine(AnimationDoor(3f));
            }
            else
            {
                MensajesUI.Instance.MostrarMensaje("Necesitas una pinza para abrir esta puerta.");
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
