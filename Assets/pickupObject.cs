using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupObject : MonoBehaviour
{
    private Transform target;
    private bool canTrigger = true;
    private Rigidbody rb;
    private Collider coll;


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
            // Follow the syringeTarget transform position
            transform.position = target.position;

            // Follow the syringeTarget transform rotation
            transform.rotation = target.rotation;
            if (OVRInput.Get(OVRInput.Button.One))
            {
                // Hide the item
                gameObject.SetActive(false);
                // Disable the Rigidbody and Collider components

            }
        }
    }
}
