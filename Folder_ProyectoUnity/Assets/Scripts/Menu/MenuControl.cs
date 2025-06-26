using UnityEngine;
using Unity.Cinemachine;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    [SerializeField] private CinemachineCamera menuCamera;
    [SerializeField] private CinemachineCamera startCamera;
    [SerializeField] private CinemachineCamera virtualCamera1;
    [SerializeField] private CinemachineCamera virtualCamera2;
    [SerializeField] private CinemachineCamera virtualCamera3;

    [SerializeField] private GameObject audioPanel;
    //[SerializeField] private GameObject creditsPanel;

    [SerializeField] private CanvasGroup mainMenu;
    //[SerializeField] private AudioSource musicSource;

    private bool startingGame = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Startmenu();
    }
    private void Startmenu()
    {
        mainMenu.DOFade(1, 2f).SetUpdate(true);
        startingGame = true;
        startCamera.Priority = 0;
        menuCamera.Priority = 100;
    }
    public IEnumerator Play()
    {
        menuCamera.Priority = 0;
        virtualCamera3.Priority = 1000;
        yield return new WaitForSeconds(2f);
        PlayEscenaGame();
    }
    public void PlayEscenaGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void PlayGame()
    {
        StartCoroutine(Play());
    }
    public void OpenAudioPanel()
    {
        mainMenu.DOFade(0, 0.5f).SetUpdate(true);
        MoveOpenPanel(audioPanel.GetComponent<RectTransform>());
        menuCamera.Priority = 0;
        virtualCamera1.Priority = 100;
    }
    public void CloseAudioPanel()
    {
        mainMenu.DOFade(1, 0.5f).SetUpdate(true);
        MoveClosePanel(audioPanel.GetComponent<RectTransform>());
        menuCamera.Priority = 100;
        virtualCamera1.Priority = 0;
    }
    private void MoveOpenPanel(RectTransform rect)
    {
        rect.DOAnchorPosY(0, 1f);
    }
    private void MoveClosePanel(RectTransform rect)
    {
        rect.DOAnchorPosY(1140, 1f);
    }
    //public void OpenCredits()
    //{
    //    creditsPanel.SetActive(true);
    //}
    //public void CloseCredits()
    //{
    //    creditsPanel.SetActive(false);
    //}
}