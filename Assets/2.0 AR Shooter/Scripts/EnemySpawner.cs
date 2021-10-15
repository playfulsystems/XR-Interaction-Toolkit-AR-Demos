using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float distFromCenter = 5f;
    public float spawnRate = 2f;
    float spawnTime;

    void Start()
    {
        spawnTime = Time.time + spawnRate;
    }

    void Update()
    {
        if (Time.time > spawnTime)
        {
            Vector2 randomPositionOnCircle = Random.insideUnitCircle.normalized * distFromCenter;
            Vector3 spawnPosition = new Vector3(randomPositionOnCircle.x, 0f, randomPositionOnCircle.y);

            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            spawnTime = Time.time + spawnRate;
        }
    }
}
