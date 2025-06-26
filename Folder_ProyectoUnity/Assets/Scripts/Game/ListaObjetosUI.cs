using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ListaObjetosUI : MonoBehaviour
{
    [Header("Prefab del texto que se mostrará en la lista")]
    public GameObject textoPrefab; // Prefab de TextMeshProUGUI

    [Header("Contenedor con Grid Layout Group (Image)")]
    public Transform contenedorLista; // Donde se instancian los textos

    [Header("Nombres de objetos recolectables")]
    public List<string> nombresObjetos = new List<string>();

    // Diccionario para guardar los textos ya instanciados
    private Dictionary<string, TextMeshProUGUI> textosGenerados = new Dictionary<string, TextMeshProUGUI>();

    void Start()
    {
        foreach (string nombre in nombresObjetos)
        {
            GameObject nuevoTexto = Instantiate(textoPrefab, contenedorLista);
            TextMeshProUGUI texto = nuevoTexto.GetComponent<TextMeshProUGUI>();
            texto.text = nombre;
            textosGenerados[nombre] = texto;
        }
    }

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
}