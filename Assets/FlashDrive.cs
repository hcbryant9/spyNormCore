using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashDrive : MonoBehaviour
{
    private Transform driveTarget;
    private bool canTrigger = true;
    public GameObject drive; // this is a reference to where the other drive should appear.
    private Rigidbody rb;
    private Collider coll;

    public Animator animator;

    private bool buttonOnePressed = false;
    private void Start()
    {
        drive.SetActive(false);
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        coll = GetComponent<Collider>(); // Get the Collider component
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canTrigger && other.CompareTag("Hand"))
        {
            canTrigger = false;
            driveTarget = other.transform;
            rb.isKinematic = true;
            coll.enabled = false;
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

            // Check if Button One is pressed
            if (OVRInput.GetDown(OVRInput.Button.One) && !buttonOnePressed)
            {
                buttonOnePressed = true;

                // Hide the item
                gameObject.SetActive(false);
                drive.SetActive(true);

                // Rotate Light
                animator.Play("rotateLight");
                
            }
        }
    }
    
    

}
