using UnityEngine;
using MoreMountains.Feedbacks;

public class DesaparecerConFeedback : MonoBehaviour
{
    #region Variables

    [SerializeField] private MMF_Player feedbackAlDesaparecer;
    [SerializeField] private float delayDestruir = 1f;

    #endregion

    #region Desaparecer

    public void Desaparecer()
    {
        if (feedbackAlDesaparecer != null)
        {
            feedbackAlDesaparecer.PlayFeedbacks();
            Destroy(gameObject, delayDestruir);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion
}
