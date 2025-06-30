using UnityEngine;
using MoreMountains.Feedbacks;

public class DesaparecerConFeedback : MonoBehaviour
{
    [SerializeField] private MMF_Player feedbackAlDesaparecer;
    [SerializeField] private float delayDestruir = 1f;

    public void Desaparecer()
    {
        if (feedbackAlDesaparecer != null)
        {
            feedbackAlDesaparecer.PlayFeedbacks();
            Destroy(gameObject, delayDestruir); // espera a que termine la animación
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

