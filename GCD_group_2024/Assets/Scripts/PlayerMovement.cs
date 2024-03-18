using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    public float runSpeed = 400.0f;
    private Vector2 input;
    private Vector2 lastMoveDirection;
    public Transform Aim;
    bool isWalking = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProccessInputs();
    }

    private void FixedUpdate()
    {
        body.velocity = input * runSpeed * Time.fixedDeltaTime;

        if (isWalking)
        {
            Vector3 vector3 = Vector3.left * input.x + Vector3.down * input.y;
            Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }
    }

    void ProccessInputs() 
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ((moveX == 0 && moveY == 0) && (input.x != 0 || input.y != 0))
        {
            isWalking = false;
            lastMoveDirection = input;
            Vector3 vector3 = Vector3.left * lastMoveDirection.x + Vector3.down * lastMoveDirection.y;
            Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }

        else if (moveX!= 0 || moveY != 0)
        {
            isWalking = true;
        }

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();
    }
}
