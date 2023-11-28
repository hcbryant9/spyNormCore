using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAnimationController : MonoBehaviour
{
    private Animator animator;
    private Vector3 previousPos;
    private VRRig vrRig;
    public float speedThreshold = 0.1f;

    [Range(0,1)]
    public float smoothing = 1;
    void Start()
    {
        animator = GetComponent<Animator>();
        vrRig = GetComponent<VRRig>();
        previousPos = vrRig.head.vrTarget.position;
    }

    // Update is called once per frame
    void Update()
    {
        //compute the speed
        Vector3 headsetSpeed = vrRig.head.vrTarget.position - previousPos / Time.deltaTime;
        headsetSpeed.y = 0;
        //local speed
        Vector3 headsetLocalSpeed = transform.InverseTransformDirection(headsetSpeed);
        previousPos = vrRig.head.vrTarget.position;

        //set animator Vales

        float previousDirectionX = animator.GetFloat("XDirection");
        float previousDirectionY = animator.GetFloat("YDirection");

        animator.SetBool("IsMoving", headsetLocalSpeed.magnitude > speedThreshold);

        animator.SetFloat("XDirection", Mathf.Lerp(previousDirectionX, Mathf.Clamp(headsetLocalSpeed.x,-1,1) , smoothing));
        animator.SetFloat("YDirection", Mathf.Lerp(previousDirectionX, Mathf.Clamp(headsetLocalSpeed.z, -1, 1), smoothing));

    }
}
