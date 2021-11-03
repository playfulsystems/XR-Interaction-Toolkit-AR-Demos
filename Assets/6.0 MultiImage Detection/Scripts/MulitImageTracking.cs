using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class MulitImageTracking : MonoBehaviour
{
    [Serializable]
    public class TrackedPrefab
    {
        public string name;
        public GameObject prefab;
    }

    private ARTrackedImageManager trackedImageManager;
    public TrackedPrefab[] prefabsToInstantiate;
    private Dictionary<string, GameObject> instantiatedPrefabs;

    private void Start()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
        instantiatedPrefabs = new Dictionary<string, GameObject>();

        trackedImageManager.trackedImagesChanged += OnTrackedImageChanged;
    }

    private void OnDestroy()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImageChanged;
    }

    private void OnTrackedImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        // if there are new images tracked, make a new one for each added
        foreach (ARTrackedImage addedImage in eventArgs.added)
        {
            InstantiateGameObject(addedImage);
        }

        // if there are images to update, update each
        foreach (ARTrackedImage updatedImage in eventArgs.updated)
        {
            // update prefab info
            string prefabName = updatedImage.referenceImage.name;
            UpdatePrefab(instantiatedPrefabs[prefabName], updatedImage.transform);

            // if tracking state limited and set to destroy, set inactive
            if (updatedImage.trackingState == TrackingState.Limited)
            {
                if (instantiatedPrefabs[prefabName].GetComponent<ARTrackedImage>().destroyOnRemoval)
                {
                    instantiatedPrefabs[prefabName].SetActive(false);
                }
            }
        }
    }

    void InstantiateGameObject(ARTrackedImage addedImage)
    {
        for (int i = 0; i < prefabsToInstantiate.Length; i++)
        {
            if (addedImage.referenceImage.name == prefabsToInstantiate[i].name)
            {
                GameObject prefab = Instantiate(prefabsToInstantiate[i].prefab, transform.parent);
                UpdatePrefab(prefab, addedImage.transform);
                instantiatedPrefabs.Add(addedImage.referenceImage.name, prefab);
            }
        }
    }

    void UpdatePrefab(GameObject prefab, Transform newTransform)
    {
        prefab.transform.position = newTransform.position;
        prefab.transform.rotation = newTransform.rotation;
        prefab.SetActive(true);
    }
}
