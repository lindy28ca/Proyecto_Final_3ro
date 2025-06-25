using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private TimeSO time;
    private void Start()
    {
        time.time = 0;
    }
    void Update()
    {
        time.time += Time.deltaTime;
    }
}
