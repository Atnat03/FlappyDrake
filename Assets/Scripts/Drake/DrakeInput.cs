using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class DrakeInput : MonoBehaviour
{
    public InputActionReference clickAction;

    private bool holdingLeft = false;
    private bool holdingRight = false;

    public Action OnPressRight;
    public Action OnPressLeft;
    public Action OnRelease;

    void OnEnable()
    {
        clickAction.action.started += OnPressStart;
        clickAction.action.canceled += OnPressEnd;
        clickAction.action.Enable();
    }

    void OnDisable()
    {
        clickAction.action.started -= OnPressStart;
        clickAction.action.canceled -= OnPressEnd;
        clickAction.action.Disable();
    }

    private void OnPressStart(InputAction.CallbackContext ctx)
    {
        Vector2 pos = Pointer.current.position.ReadValue();
        float screenMid = Screen.width / 2f;

        if (pos.x < screenMid)
        {
            holdingLeft = true;
            Debug.Log("Appui commencé côté GAUCHE");
        }
        else
        {
            holdingRight = true;
            Debug.Log("Appui commencé côté DROIT");
        }
    }

    private void OnPressEnd(InputAction.CallbackContext ctx)
    {
        if (holdingLeft)
        {
            Debug.Log("Relâché côté GAUCHE");
            holdingLeft = false;
        }
        if (holdingRight)
        {
            Debug.Log("Relâché côté DROIT");
            holdingRight = false;
        }

        OnRelease?.Invoke();
    }

    void Update()
    {
        if (holdingLeft)
        {
            Debug.Log("Encore appuyé côté GAUCHE");
            OnPressLeft?.Invoke();
        }
        else if (holdingRight)
        {
            Debug.Log("Encore appuyé côté DROIT");
            OnPressRight?.Invoke();
        }
    }
}

