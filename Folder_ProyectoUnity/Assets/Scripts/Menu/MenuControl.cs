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
    [SerializeField] private GameObject creditsPanel;

    [SerializeField] private GameObject mainMenu;

    private bool startingGame = false;

    void Update()
    {
        Startmenu();
    }
    private void Startmenu()
    {
        mainMenu.SetActive(true);
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
        mainMenu.SetActive(false);
        MoveOpenPanel(audioPanel.GetComponent<RectTransform>());
        menuCamera.Priority = 0;
        virtualCamera1.Priority = 100;
    }
    public void CloseAudioPanel()
    {
        mainMenu.SetActive(true);
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
    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        creditsPanel.SetActive(true);
        menuCamera.Priority = 0;
        virtualCamera2.Priority = 100;
    }
    public void CloseCredits()
    {
        mainMenu.SetActive(true);
        creditsPanel.SetActive(false);
        menuCamera.Priority = 100;
        virtualCamera2.Priority = 0;
    }
}