using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField]
    private float playerSpeed, jumpForce, groundDistance;

    [SerializeField]
    private float maxSpeed; //Default value in game is 10

    [SerializeField]
    private bool canJump;

    [SerializeField]
    private Rigidbody _rigidBody;

    public InputManager inputManager;
    public GameObject rbObject;
    public GameObject launcherRef;

    private Vector3 _x, _y;
    private Vector3 spawnPosition;
    private bool isMoving;
    
    private Vector3 _movementForce;

    private void Awake()
    {
        spawnPosition = transform.position;
    }

    private void Update()
    {
        if (inputManager.movementVector.x <= 0 && inputManager.movementVector.y <= 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        transform.position = rbObject.transform.position;

        rbObject.transform.localRotation = Quaternion.Euler(0, launcherRef.transform.rotation.eulerAngles.y, 0);
    }

    private void FixedUpdate()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        // Get forward vector from camera and multiply by movementVector, making the player move towards where it is aiming according to its input
        _x = rbObject.transform.forward * inputManager.movementVector.y;
        _y = rbObject.transform.right * inputManager.movementVector.x;
        
        _movementForce = (_x + _y).normalized * playerSpeed;
        
        _rigidBody.AddForce(_movementForce);

        Vector3 rbVelocity = _rigidBody.velocity;

        rbVelocity = Vector3.ClampMagnitude(rbVelocity, maxSpeed);

        _rigidBody.velocity = rbVelocity;

        //if (canJump != true)
        //{
        //    //playerSpeed = airSpeed;
        //}
        //else
        //{
        //    //playerSpeed = defaultSpeed;
        //}
    }

    public void Jump()
    {
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    if (DetectingGround())
        //    {
        //        _rigidBody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        //    }
        //}
    }

    public void ResetPos()
    {
        rbObject.transform.position = spawnPosition;
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
