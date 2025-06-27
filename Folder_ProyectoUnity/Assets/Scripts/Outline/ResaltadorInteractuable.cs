using UnityEngine;
using MoreMountains.Feedbacks;

public class ResaltadorInteractuable : MonoBehaviour
{
    private Outline outline;

    [Tooltip("Efectos visuales configurados en MMF Player (Feel v4+)")]
    public MMF_Player feedbackAlSeleccionar;

    void Start()
    {
        outline = GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = false; // Desactivado por defecto
        }     
    }

    public void ActivarResaltado()
    {
        if (outline != null)
        {
            outline.enabled = true;
        }
        if (feedbackAlSeleccionar != null)
        {
            feedbackAlSeleccionar.PlayFeedbacks();
        }
    }

    public void DesactivarResaltado()
    {
        if (outline != null)
        {
            outline.enabled = false;
        }
    }
}
