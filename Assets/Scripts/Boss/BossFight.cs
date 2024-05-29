using System.Collections;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float spawnInterval = 2f;
    public float meteorHeight = 10f;
    public float spawnRangeX = 5f;

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
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = new Vector3(spawnPosX, meteorHeight, 0);
        Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
    }
}
