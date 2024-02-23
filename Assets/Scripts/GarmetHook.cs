using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
public class GarmetHook : MonoBehaviour
{
    private Transform target;
    private bool canTrigger = true;
    private Rigidbody rb;
    private Collider coll;

    public Transform garmetHook; // reference to location where we want the garmet hook to spawn in
    

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        coll = GetComponent<Collider>(); // Get the Collider component
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canTrigger && other.CompareTag("Hand"))
        {
            Debug.Log("picked up");
            rb.isKinematic = true;
            coll.enabled = false;
            canTrigger = false;
            target = other.transform;

            
        }
    }
    void Update()
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
                // play animation for garmet hook here.
                // instantiate the garmet hook
                Realtime.Instantiate("garmetHook", garmetHook.position, garmetHook.rotation);
                // play animation
                
                // wait for animation to finish

                // disable the power switch

                // shut down the map
            }
        }
    }
}
