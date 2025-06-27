
using UnityEngine;

[DisallowMultipleComponent]
public class Outline : MonoBehaviour
{
    public enum Mode { OutlineAll, OutlineVisible, OutlineHidden, OutlineAndSilhouette, SilhouetteOnly }
    public Mode OutlineMode;
    public Color OutlineColor = Color.white;
    public float OutlineWidth = 2f;

    private Renderer[] renderers;

    void OnEnable()
    {
        renderers = GetComponentsInChildren<Renderer>();
        foreach (var rend in renderers)
        {
            foreach (var mat in rend.materials)
            {
                mat.SetFloat("_OutlineWidth", OutlineWidth);
                mat.SetColor("_OutlineColor", OutlineColor);
            }
        }
    }

    void OnDisable()
    {
        if (renderers == null) return;
        foreach (var rend in renderers)
        {
            foreach (var mat in rend.materials)
            {
                mat.SetFloat("_OutlineWidth", 0f);
            }
        }
    }
}
