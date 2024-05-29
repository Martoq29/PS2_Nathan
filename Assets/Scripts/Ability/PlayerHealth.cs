using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Image healthBar;
    public float invulnerabilityDuration = 1f; // Dur�e d'invuln�rabilit� apr�s avoir �t� touch�
    private bool isInvulnerable = false; // Indique si le joueur est invuln�rable

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        if (!isInvulnerable)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Max(currentHealth, 0); // Assure que la sant� ne descend pas en dessous de 0
            UpdateHealthBar();

            if (currentHealth <= 0)
            {
                Die();
            }

            StartCoroutine(InvulnerabilityCoroutine());
        }
    }

    IEnumerator InvulnerabilityCoroutine()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityDuration);
        isInvulnerable = false;
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
}
