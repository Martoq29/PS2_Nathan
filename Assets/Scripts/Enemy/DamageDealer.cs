using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageAmount = 20;  // Quantité de dégâts infligés au joueur

    // Cette fonction est appelée quand un autre collider entre en contact avec le trigger collider de l'ennemi
    void OnTriggerEnter(Collider other)
    {
        // Vérifie si le collider appartient à un joueur
        if (other.CompareTag("Player"))
        {
            // Obtient le composant PlayerHealth du joueur
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Inflige des dégâts au joueur
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
