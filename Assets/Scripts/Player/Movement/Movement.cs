using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool isShielded = false; // Flag to indicate if the player is shielded

    [SerializeField]
    private GameObject shield;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private PlayerHealth playerHealth; // Reference to the PlayerHealth component

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>(); // Assign the PlayerHealth component
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    public void ActivateShield(float duration)
    {
        if (!isShielded)
        {
            StartCoroutine(ShieldRoutine(duration));
        }
    }

    private IEnumerator ShieldRoutine(float duration)
    {
        isShielded = true;
        shield.SetActive(true);
        Debug.Log("Shield activated.");

        yield return new WaitForSeconds(duration);

        shield.SetActive(false);
        isShielded = false;
        Debug.Log("Shield deactivated.");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isShielded)
        {
            // Apply damage to the player's health
            playerHealth.TakeDamage(damage);
        }
        else
        {
            Debug.Log("Shield active, no damage taken.");
        }
    }

    public bool IsShielded() // Method to check if the player is shielded
    {
        return isShielded;
    }


}