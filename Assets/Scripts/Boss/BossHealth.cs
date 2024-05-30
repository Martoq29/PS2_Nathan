using System.Collections;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;
    public GameObject meteorPrefab;
    public Transform[] spawnPoints;
    public float spawnRate = 1f; // Time between meteor spawns in seconds
    private bool isMeteorActive = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= maxHealth / 2 && !isMeteorActive)
        {
            StartCoroutine(ActivateMeteors());
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private IEnumerator ActivateMeteors()
    {
        isMeteorActive = true;
        float endTime = Time.time + 10f; // Meteors active for 10 seconds

        while (Time.time < endTime)
        {
            SpawnMeteor();
            yield return new WaitForSeconds(spawnRate);
        }

        isMeteorActive = false;
    }

    private void SpawnMeteor()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(meteorPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void Die()
    {
        // Implement boss death logic here
        Debug.Log("Boss died!");
        Destroy(gameObject);
    }
}
