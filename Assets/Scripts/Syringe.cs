using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour
{
    private Transform syringeTarget;
    private bool canTrigger = true;

    private void OnTriggerEnter(Collider other)
    {
        if (canTrigger && other.CompareTag("Hand"))
        {
            canTrigger = false;
            syringeTarget = other.transform;
        }
    }

    private void Update()
    {
        if (!canTrigger && syringeTarget != null)
        {
            // Follow the syringeTarget transform position
            transform.position = syringeTarget.position;

            // Follow the syringeTarget transform rotation
            transform.rotation = syringeTarget.rotation;
            if (OVRInput.Get(OVRInput.Button.One))
            {
                // Hide the item
                gameObject.SetActive(false);
            }
        }
    }
}
