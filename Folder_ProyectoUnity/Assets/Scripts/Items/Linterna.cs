using UnityEngine;

public class Linterna : MonoBehaviour
{
    [SerializeField] ItemsInformation linterna;
    [SerializeField] private Light luz;

    private void Awake()
    {
        linterna.ItemTranform = this.transform;
    }
    private void ApagarLuz()
    {
        if(luz.enabled)
        {
            luz.enabled = false;
        }
        else
        {
            luz.enabled = true;
        }
    }
    private void OnEnable()
    {
        InputReader.Onflashlight += ApagarLuz;
    }
    private void OnDisable()
    {
        InputReader.Onflashlight -= ApagarLuz;
    }
}
