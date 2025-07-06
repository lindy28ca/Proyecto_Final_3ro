using UnityEngine;

public class Interruptor : ObjectInteractive
{
    #region Variable

    [SerializeField] private Light luz;

    #endregion

    #region Interacción

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

    #endregion
}