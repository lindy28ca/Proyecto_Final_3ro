using UnityEngine;
using DG.Tweening;

public class EscaladoEnBucle : MonoBehaviour
{
    [SerializeField] private Vector3 escalaAumentada = new Vector3(1.5f, 1.5f, 1.5f);
    [SerializeField] private float duracion = 0.5f;

    private void Start()
    {
        Vector3 escalaOriginal = transform.localScale;

        Sequence secuenciaEscala = DOTween.Sequence();
        secuenciaEscala.Append(transform.DOScale(escalaAumentada, duracion).SetEase(Ease.InOutSine));
        secuenciaEscala.Append(transform.DOScale(escalaOriginal, duracion).SetEase(Ease.InOutSine));
        secuenciaEscala.SetLoops(-1); 
    }
}
