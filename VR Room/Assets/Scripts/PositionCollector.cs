using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class XRPositions : MonoBehaviour
{
    public Vector3 leftHandPos;
    public Vector3 rightHandPos;
    public Vector3 headPos;
    public float timeOfMeasurement;
    public XRPositions ()
    {

    }
    public XRPositions (Vector3 leftHandP, Vector3 rightHandP, Vector3 headP)
    {
        leftHandPos = leftHandP;
        rightHandPos = rightHandP;
        headPos = headP;
    }
}

