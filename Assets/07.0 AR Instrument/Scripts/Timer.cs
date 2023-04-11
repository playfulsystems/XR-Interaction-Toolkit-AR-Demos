using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static event Action<int> Beat = delegate { };
    public float countdownEverySeconds;
    float counter;
    int beatNum;

    void Start()
    {
        counter = countdownEverySeconds;
        beatNum = 0;
    }

    void Update()
    {
        if (counter < 0)
        {
            Beat(beatNum); // call the delegate
            counter = countdownEverySeconds;
            beatNum++;
        }
        counter -= Time.deltaTime;
    }
}
