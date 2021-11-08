using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public float spawnRate;
    public float spawnRot;
    float spawnTime;
    float noteSpeed;

    void Start()
    {
        noteSpeed = 1f;
        spawnTime = Time.time + spawnRate;
    }

    void Update()
    {
        if (Time.time > spawnTime) {
            GameObject newNote = Instantiate(notePrefab);
            newNote.transform.position = transform.position;
            Vector3 vel = transform.forward * noteSpeed;
            newNote.GetComponent<Rigidbody>().velocity = Quaternion.Euler(0, spawnRot, 0) * vel;
            spawnTime = Time.time + spawnRate;
        }
        
    }
}
