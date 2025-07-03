using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private bool see = false;
    [SerializeField] private MovementDoTween uiList;

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
}
