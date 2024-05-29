using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damageAmount = 20;  // Quantit� de d�g�ts inflig�s au joueur

    // Cette fonction est appel�e quand un autre collider entre en contact avec le trigger collider de l'ennemi
    void OnTriggerEnter(Collider other)
    {
        // V�rifie si le collider appartient � un joueur
        if (other.CompareTag("Player"))
        {
            // Obtient le composant PlayerHealth du joueur
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Inflige des d�g�ts au joueur
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}
