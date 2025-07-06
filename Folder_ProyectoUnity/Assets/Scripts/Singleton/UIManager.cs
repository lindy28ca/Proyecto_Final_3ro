using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton

    public static UIManager Instance;

    #endregion

    #region Variables

    private bool see = false;

    [Header("UI Animación")]
    [SerializeField] private MovementDoTween uiList;

    [Header("Instrucciones")]
    [SerializeField] private GameObject panelInstrucciones;
    [SerializeField] private GameObject jugador;

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
        if (panelInstrucciones != null)
        {
            Time.timeScale = 0f;
            panelInstrucciones.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (jugador != null)
                jugador.SetActive(false);
        }
    }

    private void Update()
    {
        if (panelInstrucciones != null && panelInstrucciones.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            CerrarInstrucciones();
        }
    }

    private void OnEnable()
    {
        InputReader.OnSeeList += SeeList;
    }

    private void OnDisable()
    {
        InputReader.OnSeeList -= SeeList;
    }

    #endregion

    #region CerrarInstrucciones

    private void CerrarInstrucciones()
    {
        panelInstrucciones.SetActive(false);
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (jugador != null)
            jugador.SetActive(true);
    }

    #endregion

    #region SeeList

    public void SeeList()
    {
        if (see)
        {
            uiList.Regret(4f);
            see = false;
        }
        else
        {
            uiList.Move(Vector2.zero, 4f);
            see = true;
        }
    }

    #endregion
}
