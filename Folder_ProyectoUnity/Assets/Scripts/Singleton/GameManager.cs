using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private Transform[] newposition;
    [SerializeField] private ItemsInformation[] itemsInformation;
    [SerializeField] private Inventory inventario;
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        for(int i = 0;itemsInformation.Length > i; i++)
        {
            int positionArray = Random.Range(0, newposition.Length);
            itemsInformation[i].ItemTranform.position = newposition[positionArray].position;
        }
    }
    public void AddInventory(ItemsInformation informacion)
    {
        inventario.Add(informacion);
    }
}
