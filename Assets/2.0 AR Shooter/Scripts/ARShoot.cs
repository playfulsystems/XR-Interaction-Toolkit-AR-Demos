using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class ARShoot : MonoBehaviour
{
    ARGestureInteractor arGestureInteractor;
    public GameObject projectile;
    public float shotSpeed = 4f;

    void OnEnable()
    {
        arGestureInteractor = GetComponent<ARGestureInteractor>();
        arGestureInteractor.tapGestureRecognizer.onGestureStarted += OnTapRecognized;

        arGestureInteractor.dragGestureRecognizer.onGestureStarted += OnDragRecognized;
    }

	void Disable()
    {
        arGestureInteractor.tapGestureRecognizer.onGestureStarted -= OnTapRecognized;
        arGestureInteractor.dragGestureRecognizer.onGestureStarted -= OnDragRecognized;
    }

    private void OnDragRecognized(DragGesture obj)
    {
        Debug.Log("DRAG START: " + obj.position);
        obj.onFinished += OnDragComplete;
    }

	private void OnDragComplete(DragGesture obj)
	{
        Debug.Log("DRAG END" + obj.position);
        obj.onFinished -= OnDragComplete;
    }

    public void ChangeProjectile(GameObject newPrefab)
    {
        Debug.Log("ChangeProjectile");
        projectile = newPrefab;
    }


    private void OnTapRecognized(TapGesture obj)
    {
        //Vector2 mousePos = (Vector2)Mouse.current.position;
        Vector2 mousePos = obj.startPosition;
        if (!mousePos.IsPointOverUIObject())
        {
            GameObject newProjectile = Instantiate(projectile);
            newProjectile.transform.position = transform.position;
            Vector3 shotVelocity = transform.forward * shotSpeed;
            newProjectile.GetComponent<Rigidbody>().velocity = shotVelocity;
        }
    }
}
