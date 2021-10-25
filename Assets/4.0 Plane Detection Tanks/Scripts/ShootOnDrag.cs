using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class ShootOnDrag : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletStartPos;
    public ARGestureInteractor arGestureInteractor;
    Vector2 startDragPos;

    void Start()
    {
        arGestureInteractor = Camera.main.GetComponent<ARGestureInteractor>();
        arGestureInteractor.dragGestureRecognizer.onGestureStarted += OnDragRecognized;
    }
    private void OnDragRecognized(DragGesture obj)
    {
        Debug.Log("DRAG START");
        startDragPos = obj.position;
        GetComponent<RotateScript>().isRotating = false;
        obj.onFinished += OnDragComplete;
    }
    private void OnDragComplete(DragGesture obj)
    {
        Debug.Log("DRAG COMPLETE");
        GetComponent<RotateScript>().isRotating = true;

        Vector2 diffVector = obj.position - startDragPos;
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = bulletStartPos.transform.position;

        Vector3 bulletForce = transform.forward + new Vector3(0f, 1f, 0f);
        bulletForce *= (diffVector.magnitude * 0.01f);
        newBullet.GetComponent<Rigidbody>().AddForce(bulletForce, ForceMode.Impulse);
    }

}
