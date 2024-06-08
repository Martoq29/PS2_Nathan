using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;
    public GameObject bossFightObject; // Référence au GameObject contenant le script BossFight
    private BossFight bossFightScript; // Référence au script BossFight

    void Start()
    {
        currentHealth = maxHealth;
        bossFightScript = bossFightObject.GetComponent<BossFight>(); // Obtient une référence au script BossFight
    }

    void Update()
    {
        // Vérifie si le boss a 100 points de vie ou moins et que le script BossFight n'est pas encore activé
        if (currentHealth <= 100 && !bossFightScript.enabled)
        {
            // Active le script BossFight
            bossFightScript.enabled = true;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implement boss death logic here
        Debug.Log("Boss died!");
        Destroy(gameObject);
    }
}
