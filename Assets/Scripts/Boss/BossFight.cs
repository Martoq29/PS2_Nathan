using System.Collections;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float spawnInterval = 2f;
    public float meteorHeight = 10f;
    public float spawnRangeX = 5f;
    public float fallSpeed = 5f; // Ajoutez cette variable pour la vitesse de chute des météores

    void Start()
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
        GameObject meteor = Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
        MeteorController meteorController = meteor.GetComponent<MeteorController>();

        if (meteorController != null)
        {
            meteorController.SetFallSpeed(fallSpeed); // Passe la vitesse de chute au script de contrôle
        }
    }
}
