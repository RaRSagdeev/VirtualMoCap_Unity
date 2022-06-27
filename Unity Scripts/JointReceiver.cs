using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointReceiver : MonoBehaviour
{
    [SerializeField]
    private GameObject MirrorJoint;

    [SerializeField]
    private Vector3 JointsOffset;

    public int multiplier;
    public int secondMult;

    public void Handler(Vector3 coordinates)
    {
        Vector3 newCoord = new Vector3(coordinates.x/multiplier, coordinates.y/-secondMult, gameObject.transform.position.z);
        ChangePosition(newCoord);
    }

    private void ChangePosition(Vector3 coordinates)
    {
        transform.position = coordinates + JointsOffset;
    }
}
