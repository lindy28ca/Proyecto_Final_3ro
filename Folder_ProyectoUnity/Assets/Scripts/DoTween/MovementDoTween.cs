using UnityEngine;
using DG.Tweening;

public class MovementDoTween : MonoBehaviour
{
    [SerializeField] private Ease curve;
    [SerializeField] private RectTransform final;
    private RectTransform rectTransform;
    private Vector2 originalPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }
    private void Start()
    {
        Move(final.anchoredPosition, 1.5f);
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