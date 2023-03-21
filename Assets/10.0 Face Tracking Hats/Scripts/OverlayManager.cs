using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class OverlayManager : MonoBehaviour
{
    public GameObject[] overlays;
    int overlayNum;
    public ARGestureInteractor arGestureInteractor;
    ARFaceManager arFaceManager;

    // Update is called once per frame
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        arFaceManager = GetComponent<ARFaceManager>();
        overlayNum = -1;
        arGestureInteractor.tapGestureRecognizer.onGestureStarted += OnTap;

        OnTap(null);
    }

    private void OnTap(TapGesture obj)
    {
        // increment overlay
        overlayNum = (overlayNum + 1) % overlays.Length;

        // find all game objects with a ARFace component on it
        ARFace[] faces = GameObject.FindObjectsOfType<ARFace>();
        foreach(ARFace face in faces)
        {
            Destroy(face.gameObject);
            Debug.Log(face.gameObject.name);
        }

        // destroy and remake face manager w/new prefabs
        DestroyImmediate(arFaceManager);

        arFaceManager = gameObject.AddComponent<ARFaceManager>();
        arFaceManager.facePrefab = overlays[overlayNum];
    }
}
