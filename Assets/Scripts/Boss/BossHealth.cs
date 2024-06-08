using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;
    public GameObject bossFightObject; // R�f�rence au GameObject contenant le script BossFight
    private BossFight bossFightScript; // R�f�rence au script BossFight

    void Start()
    {
        currentHealth = maxHealth;
        bossFightScript = bossFightObject.GetComponent<BossFight>(); // Obtient une r�f�rence au script BossFight
    }

    void Update()
    {
        // V�rifie si le boss a 100 points de vie ou moins et que le script BossFight n'est pas encore activ�
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
