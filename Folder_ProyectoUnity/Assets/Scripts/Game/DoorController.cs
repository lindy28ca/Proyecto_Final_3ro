using UnityEngine;
using System.Collections;
using UnityEngine.Windows;

public class DoorController : ObjectInteractive
{
    [SerializeField] private Vector3 rotation;
    private Quaternion originRotacion;
    private Quaternion Rotation;
    private bool open;
    private void Awake()
    {
        originRotacion = transform.rotation;
        Rotation = Quaternion.Euler(rotation);
    }
    protected override void Interaccion()
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

    private void Update()
    {
        if (open)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, 5 * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originRotacion, 5 * Time.deltaTime);
        }
    }

    private IEnumerator AnimationDoor(float time)
    {
        yield return new WaitForSeconds(time);
    }


}
