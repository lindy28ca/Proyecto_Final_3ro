using UnityEngine;
using DG.Tweening;

public class MovementDoTween : MonoBehaviour
{
    [SerializeField] private Ease curve;
    private RectTransform rectTransform;
    private Vector2 originalPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void Move(Vector2 newPosition, float time)
    {
        rectTransform.DOAnchorPos(newPosition, time).SetEase(curve);
    }

    public void Regret(float time)
    {
        rectTransform.DOAnchorPos(originalPosition, time).SetEase(curve);
    }
}

