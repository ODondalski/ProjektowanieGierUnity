using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadanie2 : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = GetComponent<CharacterController>(); // U¿ywamy bezpoœrednio GetComponent na tym obiekcie
    }

    void Update()
    {
        HandleMovementInput();

        // Zmieniamy wysokoœæ gracza
        HandleJumpInput();

        // Aplikujemy grawitacjê
        ApplyGravity();

        // Ruch gracza w zale¿noœci od velocity
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void HandleMovementInput()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }

    void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
    }

    void ApplyGravity()
    {
        playerVelocity.y += gravityValue * Time.deltaTime;
    }
}
