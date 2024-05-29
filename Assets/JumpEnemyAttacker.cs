using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEnemyAttacker : MonoBehaviour
{
    [Header("For Patrolling")]
    [SerializeField] float moveSpeed;
    private float moveDirection = 1;
    private bool facingRight = true;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] float circleRadius;
    [SerializeField] LayerMask groundLayer;
    private bool checkingGround;
    private bool checkingWall;

    [Header("For JumpAttacking")]
    [SerializeField] float jumpHeight;
    [SerializeField] Transform player;
    [SerializeField] Transform groundCheck;
    [SerializeField] Vector2 boxSize;
    private bool isGrounded;

    [Header("For SeeingPlayer")]
    [SerializeField] Vector2 lineOfSite;
    [SerializeField] LayerMask playerLayer;
    private bool canSeePlayer;

    [Header("Other")]
    private Animator enemyAnim;
    private Rigidbody2D enemyRB;
    private float lastJumpTime; // Temps du dernier saut
    [SerializeField] float jumpCooldown = 2f; // Cooldown de saut en secondes

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        checkingGround = Physics2D.OverlapCircle(groundCheckPoint.position, circleRadius, groundLayer);
        checkingWall = Physics2D.OverlapCircle(wallCheckPoint.position, circleRadius, groundLayer);
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundLayer);
        canSeePlayer = Physics2D.OverlapBox(transform.position, lineOfSite, 0, playerLayer);
        AnimationController();
        if (!canSeePlayer && isGrounded)
        {
            Patrolling();
        }
        else if (canSeePlayer && isGrounded)
        {
            if (Time.time >= lastJumpTime + jumpCooldown)
            {
                JumpAttack();
                lastJumpTime = Time.time; // Met à jour le temps du dernier saut
            }
        }

    }

    void Patrolling()
    {
        if (!checkingGround || checkingWall)
        {
            Flip();
        }
        enemyRB.velocity = new Vector2(moveSpeed * moveDirection, enemyRB.velocity.y);
    }

    void JumpAttack()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;

        if (isGrounded)
        {
            // Réinitialisation de la vélocité horizontale à zéro avant le saut
            enemyRB.velocity = new Vector2(0, enemyRB.velocity.y);
            // Application de la force de saut
            enemyRB.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);
        }
    }

    void Flip()
    {
        moveDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    void AnimationController()
    {
        enemyAnim.SetBool("canSeePlayer", canSeePlayer);
        enemyAnim.SetBool("isGrounded", isGrounded);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundCheckPoint.position, circleRadius);
        Gizmos.DrawWireSphere(wallCheckPoint.position, circleRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(groundCheck.position, boxSize);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, lineOfSite);
    }
}
