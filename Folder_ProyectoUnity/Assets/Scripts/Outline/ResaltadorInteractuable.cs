using UnityEngine;
using MoreMountains.Feedbacks;

public class ResaltadorInteractuable : MonoBehaviour
{
    private Light luz;

    [SerializeField] private MMF_Player feedbackAlSeleccionar;

    void Start()
    {
        luz = GetComponentInChildren<Light>(true);
        if (luz != null)
            luz.enabled = false;
    }

    public void ActivarResaltado()
    {
        if (luz != null)
            luz.enabled = true;

        if (feedbackAlSeleccionar != null)
            feedbackAlSeleccionar.PlayFeedbacks();
    }

    public void DesactivarResaltado()
    {
        if (luz != null)
            luz.enabled = false;
    }
}
