using UnityEngine;

public class Linterna : MonoBehaviour
{
    [SerializeField] ItemsInformation linterna;

    private void Awake()
    {
        linterna.ItemTranform = this.transform;
    }
    private void Start()
    {
        print(linterna.ItemTranform.name);
    }
}
