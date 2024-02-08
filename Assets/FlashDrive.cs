using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashDrive : MonoBehaviour
{
    private Transform driveTarget;
    private bool canTrigger = true;
    public GameObject drive; // this is a reference to where the other drive should appear.

    private void Start()
    {
        drive.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (canTrigger && other.CompareTag("Hand"))
        {
            canTrigger = false;
            driveTarget = other.transform;
        }
    }

    
    private void Update()
    {
        if (!canTrigger && driveTarget != null)
        {
            // Follow the syringeTarget transform position
            transform.position = driveTarget.position;

            // Follow the syringeTarget transform rotation
            transform.rotation = driveTarget.rotation;
            if (OVRInput.Get(OVRInput.Button.One)) // tap the a button to make the drive dissapear
            {
                // Hide the item
                drive.SetActive(true);
            }
        }
    }
    
}
