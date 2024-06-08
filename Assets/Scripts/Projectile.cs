using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private float bulletSpeed = 10f; // Vitesse du projectile
    [SerializeField] private int bulletDamage = 10; // D�g�ts inflig�s par le projectile

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Configure la destruction du projectile apr�s un certain d�lai
        Destroy(gameObject, destroyTime);

        // Applique une v�locit� au projectile dans sa direction
        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // V�rifie si le projectile entre en collision avec un ennemi
        if (other.CompareTag("Enemy"))
        {
            // Obtient le composant de sant� de l'ennemi touch�
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                // Inflige des d�g�ts � l'ennemi
                enemyHealth.TakeDamage(bulletDamage);
            }

            // D�truit le projectile lorsqu'il touche un ennemi
            Destroy(gameObject);
        }
    }
}
