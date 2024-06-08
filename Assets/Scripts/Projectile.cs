using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private float bulletSpeed = 10f; // Vitesse du projectile
    [SerializeField] private int bulletDamage = 10; // Dégâts infligés par le projectile

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Configure la destruction du projectile après un certain délai
        Destroy(gameObject, destroyTime);

        // Applique une vélocité au projectile dans sa direction
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifie si le projectile entre en collision avec un ennemi
        if (other.CompareTag("Enemy"))
        {
            // Obtient le composant de santé de l'ennemi touché
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // Inflige des dégâts à l'ennemi
                enemyHealth.TakeDamage(bulletDamage);
            }

            // Détruit le projectile lorsqu'il touche un ennemi
            Destroy(gameObject);
        }
    }
}
