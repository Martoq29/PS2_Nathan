using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Image healthBar;

    // Créez un événement pour informer les observers du changement de santé du joueur
    public static event Action<PlayerHealth> OnHealthChanged;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0); // Ensure health doesn't drop below 0
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth); // Ensure health doesn't exceed the maximum
        UpdateHealthBar();
    }

    void Die()
    {
        // Implement player death logic here
        Debug.Log("Player died!");
        Destroy(gameObject);
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Clamp01((float)currentHealth / maxHealth);
        }

        // Informe les observers du changement de santé du joueur
        OnHealthChanged?.Invoke(this);
    }
}
