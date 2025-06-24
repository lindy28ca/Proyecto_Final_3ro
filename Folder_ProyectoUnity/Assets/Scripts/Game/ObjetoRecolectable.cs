using UnityEngine;

public class ObjetoRecolectable : ObjectInteractive
{
    [SerializeField] private string nombreObjeto = "Objeto";

    protected override void Interaccion()
    {
        Debug.Log(nombreObjeto + " recogido con tecla E.");

        // Primero, desactivar la entrada (muy importante)
        DesactiveInput();

        // Luego, informar al GameManager
        GameManager.Instance.RecogerObjeto();

        // Finalmente, destruir el objeto
        Destroy(gameObject);
    }
}
