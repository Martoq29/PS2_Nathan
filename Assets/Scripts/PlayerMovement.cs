using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed;
    public float JumpForce;

    Rigidbody2D rb;

    public Transform Point1;
    public Transform Point2;
    public LayerMask Ground;
    private bool IsGrounded;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GroundIsTouch();

        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.Space) && IsGrounded)
        {

            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
        }

        if (!Input.anyKey)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void GroundIsTouch()
    {
        IsGrounded = Physics2D.OverlapArea(Point1.position, Point2.position, Ground);
    }


}