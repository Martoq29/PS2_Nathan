using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // M�thode pour infliger des d�g�ts � l'ennemi
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // M�thode pour gu�rir l'ennemi

    // M�thode pour g�rer la mort de l'ennemi
    void Die()
    {
        // Ajoutez ici toute logique suppl�mentaire lorsque l'ennemi meurt
        // Par exemple, jouer une animation, donner des points au joueur, etc.

        Destroy(gameObject); // D�truit l'objet ennemi
    }
}
