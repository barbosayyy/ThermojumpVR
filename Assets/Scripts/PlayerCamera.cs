using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public bool canMoveCamera;
    public float mouseSensitivity; //Default in game is 10

    private Transform playerTransform;

    public float x;
    public float y;
    
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        LockCursor();
    }

    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        if(canMoveCamera)
        {
            x += -Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
            y += Input.GetAxisRaw("Mouse X") * mouseSensitivity;

            x = Mathf.Clamp(x, -90, 90);

            transform.localRotation = Quaternion.Euler(x, y, 0);
        }
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
