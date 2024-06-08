using UnityEngine;

public class Damageable : MonoBehaviour
{
    public float health = 100f;

    public void Damage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Ajoutez la logique de destruction de l'objet ici
        Destroy(gameObject);
    }
}
