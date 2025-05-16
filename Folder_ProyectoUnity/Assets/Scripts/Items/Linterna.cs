using UnityEngine;

public class Linterna : MonoBehaviour
{
    [SerializeField] ItemsInformation linterna;

    private void Awake()
    {
        linterna.ItemObject = this.gameObject;
    }
    private void Start()
    {
        print(linterna.ItemObject.name);
    }
}
