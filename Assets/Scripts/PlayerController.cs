using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public float rotationSpeed = 2f;

    private Rigidbody rb;
    private bool isGrounded = true;
    private int maxJumps = 2;
    private int jumpsLeft;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpsLeft = maxJumps;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;
        MovePlayer(movement);

        RotateCamera();

        // Player Jump
        if (Input.GetButtonDown("Jump") && IsMoving())
        {
            Jump();
        }

    }

    // Player and Camera Movement
    void MovePlayer(Vector3 movement)
    {
        // Translate the player in the direction of movement
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.Self);
    }

    void RotateCamera()
    {
        // Rotate the player's camera based on mouse input
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        

        // Rotate the player's transform based on horizontal mouse movement
        transform.Rotate(Vector3.up * mouseX);

    }

    // Jump when moving & Double Jump Mehcanic
    void Jump()
    {
        if (isGrounded || jumpsLeft > 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, 0f); 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;

            jumpsLeft--;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the player is grounded (collides with a surface)
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle"))
        {
            isGrounded = true;
            jumpsLeft = maxJumps;
        }
    }

    bool IsMoving()
    {
        // Check if the player is currently moving
        return Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f;
        
    }

}

    