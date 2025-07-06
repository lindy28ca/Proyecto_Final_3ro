using UnityEngine;
using TMPro;
using System.Collections;

public class MensajesUI : MonoBehaviour
{
    #region Variables

    public static MensajesUI Instance;

    [SerializeField] private GameObject panelMensaje;
    [SerializeField] private TextMeshProUGUI textoMensaje;
    [SerializeField] private float duracion = 2f;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        Instance = this;
        panelMensaje.SetActive(false);
    }

    #endregion

    #region MostrarMensaje

    public void MostrarMensaje(string mensaje)
    {
        StopAllCoroutines();
        StartCoroutine(MostrarMensajeTemporal(mensaje));
    }

    #endregion

    #region Coroutines

    private IEnumerator MostrarMensajeTemporal(string mensaje)
    {
        panelMensaje.SetActive(true);
        textoMensaje.text = mensaje;
        yield return new WaitForSecondsRealtime(duracion);
        panelMensaje.SetActive(false);
    }

    #endregion
}
