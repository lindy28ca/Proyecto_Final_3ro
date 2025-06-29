using UnityEngine;

public class ObjetoRecolectable : ObjectInteractive
{
    [Tooltip("Este nombre debe coincidir con el que est� en la lista UI")]
    public string nombreObjeto;

    private void Start()
    {
        Debug.Log("Objeto activo en escena: " + nombreObjeto + " en posici�n " + transform.position);/*unybtrvecdxs*/
    }


    protected override void Interaccion()
    {
        Debug.Log(nombreObjeto + " recogido con tecla E.");

        ListaObjetosUI lista = FindObjectOfType<ListaObjetosUI>();
        if (lista != null)
        {
            lista.TacharObjeto(nombreObjeto);
        }
        else
        {
            Debug.LogWarning("No se encontr� ListaObjetosUI en la escena.");
        }

        if (GameManager.Instance != null)
        {
            GameManager.Instance.RecogerObjeto();
        }

        DesactiveInput();

        Destroy(gameObject);
    }
}
