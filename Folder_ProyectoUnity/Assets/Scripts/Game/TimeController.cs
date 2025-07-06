using UnityEngine;

public class TimeController : MonoBehaviour
{
    #region Variables

    [SerializeField] private Puntos puntos;
    private float time;

    #endregion

    #region Unity Methods

    private void Update()
    {
        time += Time.deltaTime;
    }

    private void OnDestroy()
    {
        if (puntos != null)
        {
            puntos.AgregarPunto((int)time);
        }
    }

    #endregion
}