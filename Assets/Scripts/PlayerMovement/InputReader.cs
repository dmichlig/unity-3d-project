using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, PlayerControls.IControlsActions
{
    public Vector2 movement;
    public Vector2 cameraMovement;

    public Action OnJumpPerformed;


    private PlayerControls controls;

    private void OnEnable()
    {
        if (controls != null) return;

        controls = new PlayerControls();
        controls.Controls.SetCallbacks(this);
        controls.Controls.Enable();
    }

    public void OnDisable()
    {
        controls.Controls.Disable();
    }

    public void OnCamera(InputAction.CallbackContext context)
    {
        cameraMovement = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        OnJumpPerformed?.Invoke();
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>(); 
    }
}
