using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputActions _inputActions;
    private InputAction _movement;
    public InputAction _fire;

    public Vector2 movementVector;

    private void Awake()
    {
        _inputActions = new InputActions();
    }

    private void OnEnable()
    {
        _movement = _inputActions.Movement.Movement;
        _movement.Enable();

        _fire = _inputActions.Movement.Fire;
        _fire.Enable();
        _fire.performed += Fire;
    }

    private void OnDisable()
    {
        _movement.Disable();
        _fire.Disable();
    }

    private void Update()
    {
        movementVector = _movement.ReadValue<Vector2>();
        Debug.Log(movementVector);
    }

    public virtual void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("fired");
    }
}
