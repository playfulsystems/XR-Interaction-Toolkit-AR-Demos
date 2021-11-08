using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawnerEvent : MonoBehaviour
{
    public GameObject notePrefab;
    public float spawnRot;
    public int playOnBeat;
    float noteSpeed;

    void Start()
    {
        noteSpeed = 1f;
        Timer.Beat += HitBeat;
    }

    void HitBeat(int beatNum)
    {
        if (beatNum % playOnBeat == 0)
	    {
            GameObject newNote = Instantiate(notePrefab);
            newNote.transform.position = transform.position;
            Vector3 vel = transform.forward * noteSpeed;
            newNote.GetComponent<Rigidbody>().velocity = Quaternion.Euler(0, spawnRot, 0) * vel;
        }
    }
}
