using System.Collections;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject meteorPrefab; // Le prefab de m�t�ore
    public Transform[] spawnPoints; // Points de spawn des m�t�ores
    public float spawnInterval = 1f; // Intervalle entre les apparitions des m�t�ores

    private void Start()
    {
        StartCoroutine(SpawnMeteors());
    }

    private IEnumerator SpawnMeteors()
    {
        while (true)
        {
            SpawnMeteor();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnMeteor()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(meteorPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
