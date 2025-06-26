using UnityEngine;

public class ObjetoRecolectable : ObjectInteractive
{
    [Tooltip("Este nombre debe coincidir con el que está en la lista UI")]
    public string nombreObjeto;

    protected override void Interaccion()
    {
        Debug.Log(nombreObjeto + " recogido con tecla E.");

        // Evitar errores si no se encuentra la lista
        ListaObjetosUI lista = FindObjectOfType<ListaObjetosUI>();
        if (lista != null)
        {
            lista.TacharObjeto(nombreObjeto);
        }
        else
        {
            Debug.LogWarning("No se encontró ListaObjetosUI en la escena. Asegúrate de que esté activa y presente.");
        }

        // Notificar al GameManager si es necesario
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RecogerObjeto();
        }

        // Desactivar la interacción si tu sistema lo necesita
        DesactiveInput();

        // Destruir el objeto
        Destroy(gameObject);
    }
}