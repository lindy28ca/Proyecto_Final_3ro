using UnityEngine;

public class Linterna : MonoBehaviour
{
    #region Variables

    [SerializeField] private ItemsInformation linterna;
    [SerializeField] private Light luz;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        linterna.ItemTranform = this.transform;
    }

    private void OnEnable()
    {
        InputReader.Onflashlight += ApagarLuz;
    }

    private void OnDisable()
    {
        InputReader.Onflashlight -= ApagarLuz;
    }

    #endregion

    #region ApagarLuz

    private void ApagarLuz()
    {
        luz.enabled = !luz.enabled;
    }

    #endregion
}
