using UnityEngine;
using TMPro;
using System.Collections;
using DG.Tweening;


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
        textAlarm.transform.localScale = Vector3.zero;
        textAlarm.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);

        if (alarmCoroutine != null)
        {
            StopCoroutine(alarmCoroutine);
        }

        alarmCoroutine = StartCoroutine(AlarmCountdown(time));
    }

    public void StopAlarm()
    {
        textAlarm.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack);
        StartCoroutine(DisableTextAfterDelay(0.5f));

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
            textAlarm.text = time.ToString("0");
            yield return new WaitForSeconds(1f);
            time -= 1f;
        }

        alarmCoroutine = null;
    }
    private IEnumerator DisableTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        textAlarm.gameObject.SetActive(false);
    }
}
