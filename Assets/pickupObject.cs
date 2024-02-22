using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private Transform target;
    private bool canTrigger = true;
    private Rigidbody rb;
    private Collider coll;

    // Offset to adjust the position of the object in the hand
    public Vector3 positionOffset;

    // Offset to adjust the rotation of the object in the hand
    public Vector3 rotationOffset;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        coll = GetComponent<Collider>(); // Get the Collider component
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canTrigger && other.CompareTag("Hand"))
        {
            rb.isKinematic = true;
            coll.enabled = false;
            canTrigger = false;
            target = other.transform;
        }
    }

    private void Update()
    {
        if (!canTrigger && target != null)
        {
            // Apply offset position to the target position
            Vector3 desiredPosition = target.position + target.TransformDirection(positionOffset);

            // Follow the target transform position with the offset
            transform.position = desiredPosition;

            // Apply offset rotation to the target rotation
            Quaternion desiredRotation = target.rotation * Quaternion.Euler(rotationOffset);

            // Follow the target transform rotation with the offset
            transform.rotation = desiredRotation;

            if (OVRInput.Get(OVRInput.Button.One))
            {
                // Hide the item
                gameObject.SetActive(false);
                // Disable the Rigidbody and Collider components
            }
        }
    }
}
