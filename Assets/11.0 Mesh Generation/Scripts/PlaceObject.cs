using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class PlaceObject : MonoBehaviour
{
    public GameObject prefab;
    Camera arCamera;

    ARGestureInteractor arGestureInteractor;

    void OnEnable()
    {
        arCamera = GetComponent<Camera>();
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

            // rotate y to match direction of camera
            newObj.transform.eulerAngles = new Vector3(newObj.transform.eulerAngles.x, arCamera.transform.rotation.eulerAngles.y, newObj.transform.eulerAngles.z);

            // rotate to  match the rotation of the surface
            newObj.transform.rotation = Quaternion.FromToRotation(newObj.transform.up, hit.normal) * newObj.transform.rotation;

            // if your prefab has a rigidbody, give it a velocity... best for spheres
            newObj.GetComponent<Rigidbody>().velocity = newObj.transform.forward * 5f;
        }
    }
}
