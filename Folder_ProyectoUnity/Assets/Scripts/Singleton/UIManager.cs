using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private bool see = false;
    [SerializeField] private MovementDoTween uiList;

    [Header("Alarm")]
    [SerializeField] private TMP_Text textAlarm;

    private Coroutine alarmCoroutine; 

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

    private void OnEnable()
    {
        InputReader.OnSeeList += SeeList;
    }

    private void OnDisable()
    {
        InputReader.OnSeeList -= SeeList;
    }

    public void StartAlarm(float time)
    {
        textAlarm.gameObject.SetActive(true);

        if (alarmCoroutine != null)
        {
            StopCoroutine(alarmCoroutine);
        }

        alarmCoroutine = StartCoroutine(AlarmCountdown(time));
    }

    public void StopAlarm()
    {
        textAlarm.gameObject.SetActive(false);

        if (alarmCoroutine != null)
        {
            StopCoroutine(alarmCoroutine);
            alarmCoroutine = null;
        }
    }

    private IEnumerator AlarmCountdown(float time)
    {
        while (time > 0)
        {
            textAlarm.text = time.ToString();
            yield return new WaitForSeconds(1f);
            time -= 1f;
        }

        alarmCoroutine = null;
    }
}
