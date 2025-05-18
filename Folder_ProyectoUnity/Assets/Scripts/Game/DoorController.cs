using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Vector3 rotation;
    private Quaternion originRotacion;
    private bool open;
    private void Awake()
    {
        originRotacion = transform.rotation;
    }
    public void Interact()
    {
        if (open)
        {
            open = false;
            AnimationDoor(3f);
        }
        else
        {
            open = true;
            AnimationDoor(3f);
        }
    }

    private IEnumerator AnimationDoor(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
