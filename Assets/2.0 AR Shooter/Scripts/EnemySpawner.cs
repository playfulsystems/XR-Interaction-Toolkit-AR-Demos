using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float distFromCenter = 5f;
    public float spawnRate = 2f;
    float nextSpawn;

    void Start()
    {
        nextSpawn = spawnRate;
    }

    void Update()
    {
        if (nextSpawn < 0)
        {
            Vector2 randomPositionOnCircle = Random.insideUnitCircle.normalized * distFromCenter;
            Vector3 spawnPosition = new Vector3(randomPositionOnCircle.x, 0f, randomPositionOnCircle.y);

            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            nextSpawn = spawnRate;
        }

        nextSpawn -= Time.deltaTime;
    }
}
