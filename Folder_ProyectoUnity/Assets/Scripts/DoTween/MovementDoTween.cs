using UnityEngine;
using DG.Tweening;

public class MovementDoTween : MonoBehaviour
{
    #region Variables

    [SerializeField] private Ease curve;
    [SerializeField] private RectTransform final;
    private RectTransform rectTransform;
    private Vector2 originalPosition;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    private void Start()
    {
        Move(final.anchoredPosition, 2.3f);
    }

    #endregion

    #region Move

    public void Move(Vector2 newPosition, float time)
    {
        rectTransform.DOAnchorPos(newPosition, time).SetEase(curve);
    }
    #endregion

    #region Regret
    public void Regret(float time)
    {
        rectTransform.DOAnchorPos(originalPosition, time).SetEase(curve);
    }

    #endregion
}
