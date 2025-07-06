using UnityEngine;
using TMPro;
using System.Collections;

public class MensajesUI : MonoBehaviour
{
    public static MensajesUI Instance;

    [SerializeField] private GameObject panelMensaje;
    [SerializeField] private TextMeshProUGUI textoMensaje;
    [SerializeField] private float duracion = 2f;

    private void Awake()
    {
        Instance = this;
        panelMensaje.SetActive(false);
    }

    public void MostrarMensaje(string mensaje)
    {
        StopAllCoroutines();
        StartCoroutine(MostrarMensajeTemporal(mensaje));
    }

    private IEnumerator MostrarMensajeTemporal(string mensaje)
    {
        panelMensaje.SetActive(true);
        textoMensaje.text = mensaje;
        yield return new WaitForSecondsRealtime(duracion);
        panelMensaje.SetActive(false);
    }
}
