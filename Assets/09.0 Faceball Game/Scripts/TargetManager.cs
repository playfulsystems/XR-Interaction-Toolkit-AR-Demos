using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    void Start()
    {
        SelectNewTarget(null);
    }

    public void SelectNewTarget(Target hitTarget)
    {
        // finding all children w/Target script (ignores parent)
        Target[] targets = GetComponentsInChildren<Target>();

        // convert to a list so we can remove hitTarget
        List<Target> targetList = new List<Target>(targets);

        // remove hitTarget
        if (hitTarget != null) targetList.Remove(hitTarget);

        // get random target num
        int randTargetNum = Random.Range(0, targetList.Count);

        // turn it on
        targetList[randTargetNum].Toggle(true);
    }
}
