using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private float normalBulletSpeed = 10f;
    [SerializeField] private float normalBulletDamage = 1f;

    private Rigidbody2D rb;
    private float damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SetDestroyTime();
        damage = normalBulletDamage;
    }

    public void SetStraightVelocity(Vector2 direction)
    {
        rb.velocity = direction * normalBulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Logique de dégâts ici si nécessaire

            Destroy(gameObject);
        }
    }

    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime);
    }
}
