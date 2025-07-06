using UnityEngine;

public class ObjetoRecolectable : ObjectInteractive
{
    #region Variable

    public string nombreObjeto;

    #endregion

    #region Unity Methods

    private void Start()
    {
        Debug.Log("Objeto activo en escena: " + nombreObjeto + " en posici�n " + transform.position);
    }

    #endregion

    #region Interacci�n

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

    #endregion
}
