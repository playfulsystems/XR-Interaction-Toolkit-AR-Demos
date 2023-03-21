using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class ARPlacementInteractableBlocking : ARPlacementInteractable
{
    protected override bool CanStartManipulationForGesture(TapGesture gesture)
    {
        if (gesture.startPosition.IsPointOverUIObject())
		{
            return false;
		}

        // allow for test planes
        if (gesture.targetObject == null || gesture.targetObject.layer == 9)
		{
            return true;
		}

        return false;
    }
}
