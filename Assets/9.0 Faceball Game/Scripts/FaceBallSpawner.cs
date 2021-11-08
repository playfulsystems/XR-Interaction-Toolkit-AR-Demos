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
            GameObject newPrefab = Instantiate(prefab, transform.position, transform.rotation);

            newPrefab.GetComponent<FaceBall>().SetVelocityToTarget(transform.forward);
            spawnCountdown = spawnFreq;
            Debug.Log("spawnCountdown: " + spawnCountdown);
        }
        spawnCountdown -= Time.deltaTime;
    }

}
