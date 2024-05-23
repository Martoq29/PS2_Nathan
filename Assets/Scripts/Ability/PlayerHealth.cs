using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Ce ne devrait pas être static
    public int currentHealth;
    public Image healthBar;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0); // Assure que la santé ne descend pas en dessous de 0
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Assure que la santé ne dépasse pas le maximum
        UpdateHealthBar();
    }

    void Die()
    {
        // Implémentez la logique de mort du joueur ici
        Debug.Log("Player died!");
        Destroy(gameObject);
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Clamp01((float)currentHealth / maxHealth);
        }
    }

    void Update()
    {
        // Optionnel : Si vous souhaitez mettre à jour la barre de santé chaque frame
        // UpdateHealthBar();
    }
}
