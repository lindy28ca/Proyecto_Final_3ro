using UnityEngine;

[CreateAssetMenu(fileName = "ItemsInformation", menuName = "Scriptable Objects/ItemsInformation", order = 1)]
public class ItemsInformation : ScriptableObject
{
    #region Variables Públicas

    public string pinza;
    public Transform ItemTranform;
    public Sprite ItemSprite;
    public Vector3 ItemRotation;

    #endregion

    #region UpdateRotation
    public void UpdateRotation()
    {
        ItemTranform.transform.localRotation = Quaternion.Euler(ItemRotation);
    }

    #endregion
}

