using UnityEngine;
using MoreMountains.Feedbacks;

public class ResaltadorInteractuable : MonoBehaviour
{
    #region Variables

    private Light luz;
    [SerializeField] private MMF_Player feedbackAlSeleccionar;

    #endregion

    #region Unity Method

    private void Start()
    {
        luz = GetComponentInChildren<Light>(true);
        if (luz != null)
            luz.enabled = false;
    }

    #endregion

    #region ActivarResaltado

    public void ActivarResaltado()
    {
        if (luz != null)
            luz.enabled = true;

        if (feedbackAlSeleccionar != null)
            feedbackAlSeleccionar.PlayFeedbacks();
    }
    #endregion

    #region DesactivarResaltado
    public void DesactivarResaltado()
    {
        if (luz != null)
            luz.enabled = false;
    }

    #endregion
}
