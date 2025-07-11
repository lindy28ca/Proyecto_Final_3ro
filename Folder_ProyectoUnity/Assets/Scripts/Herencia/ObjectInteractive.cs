using UnityEngine;

public abstract class ObjectInteractive : MonoBehaviour
{
    #region M�todos de Interacci�n

    protected abstract void Interaccion();

    public void ActiveInput()
    {
        InputReader.OnInteractive += Interaccion;
    }

    public void DesactiveInput()
    {
        InputReader.OnInteractive -= Interaccion;
    }

    #endregion
}