using UnityEngine;

public class Interruptor : ObjectInteractive
{
    [SerializeField] private Light luz;
    protected override void Interaccion()
    {
        if (luz.enabled)
        {
            luz.enabled = false;
        }
        else
        {
            luz.enabled = true;
        }
    }
}
