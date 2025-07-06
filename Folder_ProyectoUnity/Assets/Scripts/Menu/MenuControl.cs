using UnityEngine;
using Unity.Cinemachine;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    #region Variables

    [SerializeField] private CinemachineCamera menuCamera;
    [SerializeField] private CinemachineCamera startCamera;
    [SerializeField] private CinemachineCamera virtualCamera1;
    [SerializeField] private CinemachineCamera virtualCamera2;
    [SerializeField] private CinemachineCamera virtualCamera3;

    [SerializeField] private GameObject audioPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject mainMenu;

    private bool startingGame = false;

    #endregion

    #region Unity Methods

    private void Update()
    {
        Startmenu();
    }

    #endregion

    #region Menú Principal

    private void Startmenu()
    {
        mainMenu.SetActive(true);
        startingGame = true;
        startCamera.Priority = 0;
        menuCamera.Priority = 100;
    }

    public void PlayGame()
    {
        StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        menuCamera.Priority = 0;
        virtualCamera3.Priority = 1000;
        yield return new WaitForSeconds(2f);
        PlayEscenaGame();
    }

    private void PlayEscenaGame()
    {
        SceneManager.LoadScene("Game");
    }

    #endregion

    #region Panel de Audio

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

    #endregion

    #region Panel de Créditos

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

    #endregion

    #region Movimiento UI

    private void MoveOpenPanel(RectTransform rect)
    {
        rect.DOAnchorPosY(0, 1f);
    }

    private void MoveClosePanel(RectTransform rect)
    {
        rect.DOAnchorPosY(1140, 1f);
    }

    #endregion
}