using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTopView : MonoBehaviour
{
    public float movementSpeed = 1f;
    public Rigidbody2D rb2d;
    public float revSpeed = 50.0f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        GetInputMovement();
    }

    public void GetInputMovement()
    {
        Vector2 currentPos = rb2d.position;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        rb2d.MovePosition(newPos);

        float currentRot = rb2d.rotation;

        rb2d.MoveRotation(rb2d.rotation + revSpeed * Time.fixedDeltaTime);

    }
}
