using UnityEngine;

public class PinzaController : ObjectInteractive
{
    [SerializeField] ItemsInformation pinza;
    private void Awake()
    {
        pinza.ItemTranform = this.transform;
    }
    protected override void Interaccion()
    {
        GameManager.Instance.AddInventory(pinza);
    }
}
