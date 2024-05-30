using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10;
    public float bulletSpeed = 10f; // Nouvelle variable pour la vitesse de la balle

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed; // Définir la vélocité de la balle
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // Inflige des dégâts à l'ennemi
                enemyHealth.TakeDamage(damage);

                // Détruire la balle après avoir touché l'ennemi
                Destroy(gameObject);
            }
        }
    }
}
