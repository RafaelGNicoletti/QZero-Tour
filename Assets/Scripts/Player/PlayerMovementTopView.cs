using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTopView : PlayerMovement
{
    public float rotateSpeed = 1f;
    public Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Pega o input de movimento dado e traduz isso na translação e rotação do jogador.
    /// </summary>
    public override void GetInputMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Move(horizontalInput, verticalInput);
        Rotate(horizontalInput, verticalInput);
    }

    /// <summary>
    /// Aplica os valores dados na translação.
    /// </summary>
    /// <param name="horizontal"></param>
    /// <param name="vertical"></param>
    private void Move(float horizontal, float vertical)
    {
        Vector2 currentPos = rb2d.position;
        Vector2 inputVector = new Vector2(horizontal, vertical);
        inputVector = Vector2.ClampMagnitude(inputVector, 1);
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        rb2d.MovePosition(newPos);

    }

    /// <summary>
    /// Aplica os valores dados na rotação.
    /// </summary>
    /// <param name="horizontal"></param>
    /// <param name="vertical"></param>
    private void Rotate(float horizontal, float vertical)
    {
        if (horizontal != 0 || vertical != 0)
        {
            float heading = Mathf.Atan2(-horizontal, vertical);
            Quaternion rotate = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);
            rotate = Quaternion.Lerp(transform.rotation, rotate, Time.deltaTime * rotateSpeed);
            rb2d.MoveRotation(rotate);
        }
    }
}