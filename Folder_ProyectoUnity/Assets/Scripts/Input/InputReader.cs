using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputReader : MonoBehaviour
{
    #region Eventos

    public static event Action<Vector2> OnMovePlayer;
    public static event Action<float> OnScroll;
    public static event Action OnSeeList;
    public static event Action Onflashlight;
    public static event Action OnInteractive;

    #endregion

    #region Métodos de Input

    public void InputMovePlayer(InputAction.CallbackContext context)
    {
        OnMovePlayer?.Invoke(context.ReadValue<Vector2>());
    }

    public void InputScroll(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnScroll?.Invoke(context.ReadValue<Vector2>().normalized.y);
        }
    }

    public void InputSeeList(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnSeeList?.Invoke();
        }
    }

    public void InputLinterna(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Onflashlight?.Invoke();
        }
    }

    public void InputInteractive(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnInteractive?.Invoke();
        }
    }

    #endregion
}