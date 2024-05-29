using System.Collections;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;

    private bool meteorPhaseActivated = false;
    public GameObject bossFightController; // Reference to the BossFightController GameObject

    void Start()
    {
        currentHealth = maxHealth;
        bossFightController.SetActive(false); // Disable meteor spawning initially
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0); // Ensure health doesn't drop below 0

        if (currentHealth <= maxHealth / 2 && !meteorPhaseActivated)
        {
            meteorPhaseActivated = true;
            StartCoroutine(ActivateMeteorPhase());
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Implement boss death logic here
        Debug.Log("Boss died!");
        Destroy(gameObject);
    }

    private IEnumerator ActivateMeteorPhase()
    {
        bossFightController.SetActive(true); // Activate meteor spawning
        yield return new WaitForSeconds(10f);
        bossFightController.SetActive(false); // Deactivate meteor spawning
    }
}
