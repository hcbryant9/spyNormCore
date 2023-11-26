using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        rigTarget.SetPositionAndRotation(vrTarget.TransformPoint(trackingPositionOffset), vrTarget.rotation * Quaternion.Euler(trackingRotationOffset));
    }
}
public class VRRig : MonoBehaviour
{
    public Transform headConstraint;
    public Vector3 headBodyOffset;

    public VRMap head;
    public VRMap lefthand;
    public VRMap righthand;

    void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = headConstraint.position + headBodyOffset;
        transform.forward = Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized;

        head.Map();
        lefthand.Map();
        righthand.Map();
    }
}
