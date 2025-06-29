using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private Puntos puntos;
    private float time;
    void Update()
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

}
