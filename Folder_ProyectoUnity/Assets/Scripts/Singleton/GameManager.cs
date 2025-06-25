using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Transform[] newposition;                  
    [SerializeField] private ItemsInformation[] itemsInformation;       
    [SerializeField] private Inventory inventario;                     
    [SerializeField] private Transform[] positionRamdom;               
    [SerializeField] private GameObject[] prefabs;                      
    private int objetosRecogidos = 0;
    [SerializeField] private int totalObjetos = 7;

    [SerializeField] private float puntos;
    [SerializeField] private Puntos puntosSO;
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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        for (int i = 0; i < itemsInformation.Length; i++)
        {
            int positionArray = Random.Range(0, newposition.Length);
            itemsInformation[i].ItemTranform.position = newposition[positionArray].position;
        }

        InstanciarPrefabsEnPosiciones();
    }
    private void Update()
    {
        puntos += Time.deltaTime;
    }
    public void AddInventory(ItemsInformation informacion)
    {
        inventario.Add(informacion);
    }

    private void InstanciarPrefabsEnPosiciones()
    {
        if (positionRamdom.Length < prefabs.Length)
        {
            Debug.LogWarning("Hay más prefabs que posiciones, algunos se repetirán.");
        }

        Transform[] posicionesMezcladas = new Transform[positionRamdom.Length];
        positionRamdom.CopyTo(posicionesMezcladas, 0);

        for (int i = 0; i < posicionesMezcladas.Length; i++)
        {
            int randomIndex = Random.Range(i, posicionesMezcladas.Length);
            Transform temp = posicionesMezcladas[i];
            posicionesMezcladas[i] = posicionesMezcladas[randomIndex];
            posicionesMezcladas[randomIndex] = temp;
        }

        for (int i = 0; i < prefabs.Length; i++)
        {
            Transform posicionAsignada = posicionesMezcladas[i % posicionesMezcladas.Length];
            Instantiate(prefabs[i], posicionAsignada.position, Quaternion.identity);
        }
    }
    public void RecogerObjeto()
    {
        objetosRecogidos++;
        Debug.Log("Objetos recogidos: " + objetosRecogidos);

        if (objetosRecogidos >= totalObjetos)
        {
            Debug.Log("¡Ganaste! Cargando escena...");
            puntosSO.AgregarPunto((int)puntos);
            SceneManager.LoadScene("Ganaste"); 
        }
    }
}
