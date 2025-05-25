using UnityEngine;

public abstract class ObjectInteractive : MonoBehaviour
{
    protected abstract void Interaccion();
    public void ActiveInput()
    {
        InputReader.OnInteractive += Interaccion;
    }
    public void DesactiveInput()
    {
        InputReader.OnInteractive -= Interaccion;
    }
}
