using UnityEngine;

public class Meteor : MonoBehaviour
{
    public int damage = 10;
    public float fallSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int collisionLayer = collision.gameObject.layer;
        string collisionLayerName = LayerMask.LayerToName(collisionLayer);

        if (collisionLayerName == "Player")
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject); // Destroy meteor on collision with player
        }
        else if (collisionLayerName == "Ground")
        {
            Destroy(gameObject); // Destroy meteor on collision with ground
        }
    }
}
