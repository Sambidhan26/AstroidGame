using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float maxVelocity;
    [SerializeField]
    private float rotationSpeed;

    private Vector3 movementDirection;

    private Camera mainCamera;
    private Rigidbody playerRB;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        PlayerInsideScreen();
        RotateToFaceDirection();
    }

    private void FixedUpdate()
    {
        if(movementDirection == Vector3.zero)
        {
            return;
        }

        playerRB.AddForce(movementDirection * acceleration, ForceMode.Force);

        playerRB.velocity =  Vector3.ClampMagnitude(playerRB.velocity, maxVelocity);
    }

    private void ProcessInput()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            //Debug.Log(touchPosition);

            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);
            //Debug.Log(worldPosition);

            movementDirection = transform.position - worldPosition;
            movementDirection.z = 0f;
            movementDirection.Normalize();
        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }

    private void PlayerInsideScreen()
    {
        Vector3 newPosition = transform.position;
        Vector3 viewPortPosition = mainCamera.WorldToViewportPoint(transform.position);

        if(viewPortPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f;
        }
        else if(viewPortPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;
        }

        if(viewPortPosition.y > 1)
        {
            newPosition.y = -newPosition.y + 0.1f;
        }
        else if(viewPortPosition.y < 0)
        {
            newPosition.y = -newPosition.y - 0.1f;
        }

        transform.position = newPosition;
    }

    private void RotateToFaceDirection()
    {
        if(playerRB.velocity == Vector3.zero)
        {
            return;
        }

        Quaternion targetRotation =  Quaternion.LookRotation(playerRB.velocity, Vector3.back);

        transform.rotation =  Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }
}
