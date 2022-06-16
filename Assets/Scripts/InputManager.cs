using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputActions _inputActions;
    public InputAction movement;
    public InputAction fire;

    public Vector2 movementVector;

    private void Awake()
    {
        _inputActions = new InputActions();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        movement = _inputActions.Movement.Movement;
        movement.Enable();

        fire = _inputActions.Movement.Fire;
        fire.Enable();
    }

    private void OnDisable()
    {
        movement.Disable();
        fire.Disable();
    }

    private void Update()
    {
        movementVector = movement.ReadValue<Vector2>();
    }
}
