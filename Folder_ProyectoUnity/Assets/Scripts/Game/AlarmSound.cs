using UnityEngine;
using System;

public class AlarmSound : MonoBehaviour
{
    public static event Action OnAlarm;
    [SerializeField] private float time;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.StartAlarm(time);
        }
    }
}
