using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void CambiarScena(string escena)
    {
        SceneManager.LoadScene(escena);
    }
    public void Salir()
    {
        Debug.Log("Saliste del juego");
        Application.Quit();
    }
}
