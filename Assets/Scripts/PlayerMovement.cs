using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField]
    private float hMovement, vMovement, playerSpeed, jumpForce, groundDistance;

    [SerializeField]
    private float maxVerticalSpeed, maxHorizontalSpeed; //Default value in game is 10

    [SerializeField]
    private bool canJump;

    private Vector3 _x, _z, _movement, _moveDirection;

    private Rigidbody _rigidBody;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //hMovement = _inputMaster.PlayerInput.Sideways.ReadValue<float>();
        //vMovement = _inputMaster.PlayerInput.Forward.ReadValue<float>();
        hMovement = Input.GetAxisRaw("Horizontal");
        vMovement = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        _x = transform.right * hMovement;
        _z = transform.forward * vMovement;

        _movement = (_x + _z).normalized * playerSpeed;

        _moveDirection = transform.forward * vMovement + transform.right * hMovement;

        _rigidBody.AddForce(_movement);

        Vector3 velocity = _rigidBody.velocity;
        float vertVelocity = velocity.y;

        velocity.y = 0;

        velocity = Vector3.ClampMagnitude(velocity, maxHorizontalSpeed);

        velocity.y = vertVelocity;
        _rigidBody.velocity = velocity;

        if (canJump != true)
        {
            //playerSpeed = airSpeed;
        }
        else
        {
            //playerSpeed = defaultSpeed;
        }
    }

    public void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (DetectingGround())
            {
                _rigidBody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    private bool DetectingGround()
    {
        Vector3 raycastPoint = new Vector3(0, -0.5f, 0);
        bool groundRay = Physics.Raycast(raycastPoint, Vector3.down, 0.5f);

        if (groundRay)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
