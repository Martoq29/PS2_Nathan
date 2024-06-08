using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Image healthBar;

    private bool isInvincible = false;
    private float invincibilityDuration = 1f;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0); // Ensure health doesn't drop below 0
        UpdateHealthBar();

        Debug.Log($"{gameObject.name} took damage. Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }

        StartCoroutine(InvincibilityCoroutine());
    }

    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
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
        Debug.Log($"{gameObject.name} died!");
        Destroy(gameObject);
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Clamp01((float)currentHealth / maxHealth);
        }
    }
}
