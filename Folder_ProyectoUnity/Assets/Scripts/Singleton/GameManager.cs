using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;

    #endregion

    #region Referencias

    [Header("Referencias")]
    [SerializeField] private Inventory inventario;
    [SerializeField] private ItemsInformation objetoInicial;
    [SerializeField] private ItemsInformation[] itemsInformation;
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Transform[] newposition;
    [SerializeField] private Transform[] positionRamdom;

    #endregion

    #region Puntaje

    [Header("Puntaje")]
    [SerializeField] private float puntos;
    [SerializeField] private Puntos puntosSO;

    #endregion

    #region Control de Objetos

    private int objetosRecolectados = 0;
    [SerializeField] private int totalObjetos = 7;

    #endregion

    #region Unity Methods

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

        if (objetoInicial != null)
        {
            AddInventory(objetoInicial);
        }

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

    #endregion

    #region M�todos P�blicos

    public void AddInventory(ItemsInformation informacion)
    {
        inventario.Add(informacion);
    }

    public void RecogerObjeto()
    {
        objetosRecolectados++;

        if (objetosRecolectados >= totalObjetos)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            puntosSO.AgregarPunto((int)puntos);
            SceneManager.LoadScene("Ganaste");
        }
    }

    public bool TieneObjeto(string nombre)
    {
        return inventario.Contiene(nombre);
    }

    public bool PinzaEnMano(string nombre)
    {
        return inventario != null && inventario.PinzaEnMano(nombre);
    }

    #endregion

    #region M�todos Privados

    private void InstanciarPrefabsEnPosiciones()
    {
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

    #endregion
}