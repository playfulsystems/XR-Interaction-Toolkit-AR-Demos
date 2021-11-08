using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public Target[] targets;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        SelectNewTarget(null);
    }

    public void SelectNewTarget(Target hitTarget)
    {
        Target randTarget = null;
        while (hitTarget == randTarget || randTarget == null)
        {
            int randTargetNum = Random.Range(0, targets.Length);
            randTarget = targets[randTargetNum];
        }
        randTarget.Toggle(true);
    }
}
