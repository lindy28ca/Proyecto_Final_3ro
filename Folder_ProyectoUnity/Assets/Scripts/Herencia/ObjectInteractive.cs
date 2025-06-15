using UnityEngine;
using DG.Tweening; 

public abstract class ObjectInteractive : MonoBehaviour
{
    private Transform objectTransform;

    protected virtual void Start()
    {
        objectTransform = transform;

        objectTransform.DOScale(1.1f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
    protected abstract void Interaccion();
    public void ActiveInput()
    {
        InputReader.OnInteractive += HandleInteraction;
    }
    public void DesactiveInput()
    {
        InputReader.OnInteractive -= HandleInteraction;
    }
    private void HandleInteraction()
    {
        Interaccion();

        objectTransform.DOPunchRotation(new Vector3(0, 15, 0), 0.5f, 5, 1);
    }
}
