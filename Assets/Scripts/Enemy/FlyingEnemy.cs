using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed;
    public bool chase = false;
    public Transform startingPoint;
    public string playerTag = "Player"; // Variable pour le tag du joueur
    public int damage = 20; // Quantité de dégâts infligés

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag(playerTag); // Essayez de trouver le joueur à nouveau
            if (player == null)
            {
                return;
            }
        }

        if (chase)
        {
            Chase();
        }
        else
        {
            ReturnStartPoint();
        }
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            chase = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            chase = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
