using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static int maxHealth = 100;
    public static int currentHealth;
    public Image healthBar;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    void Update()
    {
        
        healthBar.fillAmount = Mathf.Clamp01((float)currentHealth / maxHealth);
    }
}
