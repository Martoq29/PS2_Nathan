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
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private TrailRenderer tr;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (isDashing)
        {
            return;
        }
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
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

    }

    void GroundIsTouch()
    {
        IsGrounded = Physics2D.OverlapArea(Point1.position, Point2.position, Ground);
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}