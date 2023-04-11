using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class PlaceObject : MonoBehaviour
{
    public GameObject prefab;
    public Camera arCamera;
    ARGestureInteractor arGestureInteractor;

    void OnEnable()
    {
        arGestureInteractor = GetComponent<ARGestureInteractor>();
        arGestureInteractor.tapGestureRecognizer.onGestureStarted += OnTapRecognized;
    }
    private void OnTapRecognized(TapGesture obj)
    {
        Ray ray = arCamera.ScreenPointToRay(obj.startPosition);
        bool rayhit = Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity);

        if (rayhit)
        {
            GameObject newObj = Instantiate(prefab);

            newObj.transform.position = hit.point;
            newObj.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            newObj.transform.rotation = Quaternion.Euler(newObj.transform.rotation.x, arCamera.transform.rotation.eulerAngles.y, newObj.transform.rotation.z);

            newObj.GetComponent<Rigidbody>().velocity = newObj.transform.forward * 5f;
        }
    }

}
