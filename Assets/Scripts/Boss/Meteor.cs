using UnityEngine;

public class Meteor : MonoBehaviour
{
    public int damage = 10;
    public float fallSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject); // Destroy meteor on collision with player
        }
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject); // Destroy meteor on collision with ground
        }
    }
}
