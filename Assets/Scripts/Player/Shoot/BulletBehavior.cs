using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private float normalBulletSpeed = 10f; // Ajout de la vitesse de la balle
    [SerializeField] private float normalBulletDamage = 1f;

    private Rigidbody2D rb;
    private float damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SetDestroyTime();

        SetStraightVelocity();

        damage = normalBulletDamage; // Initialisation de la variable damage
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si la collision se produit avec un objet portant le tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            

            Destroy(gameObject);
        }
    }

    private void SetStraightVelocity()
    {
        rb.velocity = transform.right * normalBulletSpeed;
    }

    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime);
    }
}
