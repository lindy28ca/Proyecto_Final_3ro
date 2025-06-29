using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Inventory inventario;
    [SerializeField] private ItemsInformation objetoInicial; // Asigna la pinza desde el Inspector

    private int objetosRecolectados = 0;
    private const int totalObjetosNecesarios = 7;

    private void Awake()
    {
        if (Instance != null && Instance != this)
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
        if (objetoInicial != null)
        {
            AddInventory(objetoInicial); // Añadir la pinza al comenzar
        }
    }

    public void AddInventory(ItemsInformation informacion)
    {
        inventario.Add(informacion);
    }

    public void RecogerObjeto()
    {
        objetosRecolectados++;

        if (objetosRecolectados >= totalObjetosNecesarios)
        {
            SceneManager.LoadScene("Ganaste");
        }
    }

    public bool TieneObjeto(string nombre)
    {
        return inventario.Contiene(nombre);
    }
}
