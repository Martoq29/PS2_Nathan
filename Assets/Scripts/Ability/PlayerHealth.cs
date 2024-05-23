using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Ce ne devrait pas �tre static
    public int currentHealth;
    public Image healthBar;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0); // Assure que la sant� ne descend pas en dessous de 0
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Assure que la sant� ne d�passe pas le maximum
        UpdateHealthBar();
    }

    void Die()
    {
        // Impl�mentez la logique de mort du joueur ici
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
        // Optionnel : Si vous souhaitez mettre � jour la barre de sant� chaque frame
        // UpdateHealthBar();
    }
}
