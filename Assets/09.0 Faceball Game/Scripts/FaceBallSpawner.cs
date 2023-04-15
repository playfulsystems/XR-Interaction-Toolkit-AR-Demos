using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class FaceBallSpawner : MonoBehaviour
{
    public GameObject prefab;
    GameObject target;
    float spawnFreq = 2f;
    float spawnCountdown;

    void Start()
    {
        spawnCountdown = spawnFreq;

    }

    void Update()
    {
        //Debug.Log(transform.GetComponentInParent<ARFaceManager>().trackables.count);

        if (spawnCountdown < 0)
        {
            // creating and positioning a new ball
            GameObject newBall = Instantiate(prefab);
            newBall.transform.position = transform.position;
            spawnCountdown = spawnFreq;

            // set velocity to the direction the camera is facing
            Rigidbody rb = newBall.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 0.5f;
        }
        spawnCountdown -= Time.deltaTime;
    }

}
