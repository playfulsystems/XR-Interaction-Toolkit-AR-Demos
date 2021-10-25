using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public float RotateSpeed = 2.0f;
    public bool isRotating = true;
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(0f, RotateSpeed, 0f);
        }
    }

}
