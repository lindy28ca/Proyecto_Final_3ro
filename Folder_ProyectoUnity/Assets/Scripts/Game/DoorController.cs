using UnityEngine;
using System.Collections;

public class DoorController : ObjectInteractive
{
    #region Variables

    [SerializeField] private Vector3 rotation;
    [SerializeField] private string nombreObjetoRequerido = "Pinza";

    private Quaternion rotacionInicial;
    private Quaternion rotacionFinal;
    private bool abierta;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        rotacionInicial = transform.rotation;
        rotacionFinal = Quaternion.Euler(rotation);
    }

    private void Update()
    {
        Quaternion destino = abierta ? rotacionFinal : rotacionInicial;
        transform.rotation = Quaternion.Slerp(transform.rotation, destino, 5 * Time.deltaTime);
    }

    #endregion

    #region Interacción

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
    #endregion

    #region AnimationDoor
    private IEnumerator AnimationDoor(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
    }

    #endregion
}
