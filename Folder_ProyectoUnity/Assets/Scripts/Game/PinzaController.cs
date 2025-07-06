using UnityEngine;

public class PinzaController : ObjectInteractive
{
    #region Variable

    [SerializeField] private ItemsInformation pinza;

    #endregion

    #region Unity Method

    private void Awake()
    {
        pinza.ItemTranform = this.transform;
    }

    #endregion

    #region Interacción

    protected override void Interaccion()
    {
        GameManager.Instance.AddInventory(pinza);
    }

    #endregion
}
