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

    // Méthode pour infliger des dégâts à l'ennemi
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Méthode pour guérir l'ennemi

    // Méthode pour gérer la mort de l'ennemi
    void Die()
    {
        // Ajoutez ici toute logique supplémentaire lorsque l'ennemi meurt
        // Par exemple, jouer une animation, donner des points au joueur, etc.

        Destroy(gameObject); // Détruit l'objet ennemi
    }
}
