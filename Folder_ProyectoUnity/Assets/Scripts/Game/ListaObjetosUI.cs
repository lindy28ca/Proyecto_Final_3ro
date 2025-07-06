using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ListaObjetosUI : MonoBehaviour
{
    #region Variables

    public GameObject textoPrefab;
    public Transform contenedorLista;
    public List<string> nombresObjetos = new List<string>();

    private Dictionary<string, TextMeshProUGUI> textosGenerados = new Dictionary<string, TextMeshProUGUI>();

    #endregion

    #region Unity Methods

    private void Start()
    {
        foreach (string nombre in nombresObjetos)
        {
            GameObject nuevoTexto = Instantiate(textoPrefab, contenedorLista);
            TextMeshProUGUI texto = nuevoTexto.GetComponent<TextMeshProUGUI>();
            texto.text = nombre;
            textosGenerados[nombre] = texto;
        }
    }

    #endregion

    #region TacharObjeto

    public void TacharObjeto(string nombre)
    {
        if (textosGenerados.ContainsKey(nombre))
        {
            var texto = textosGenerados[nombre];
            texto.fontStyle = FontStyles.Strikethrough;
            texto.color = Color.gray;
        }
        else
        {
            Debug.LogWarning("No se encontró el nombre en la lista: " + nombre);
        }
    }

    #endregion
}
