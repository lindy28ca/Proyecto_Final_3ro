using UnityEngine;

[CreateAssetMenu(fileName = "ItemsInformation", menuName = "Scriptable Objects/ItemsInformation", order = 1)]
public class ItemsInformation : ScriptableObject
{
    public string pinza; 
    public Transform ItemTranform;
    public Sprite ItemSprite;
    public Vector3 ItemRotation;

    public void UpdateRotation()
    {
        ItemTranform.transform.localRotation = Quaternion.Euler(ItemRotation);
    }
}
