using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    private Transform target;
    private bool canTrigger = true;
    private Rigidbody rb;
    private Collider coll;

    //public Animator animator;

    public GameObject unlockedKey;
    public GameObject lockedlock;
    public GameObject unlockedlock;

    public Animator cabinetAnimator;
   
    
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        coll = GetComponent<Collider>(); // Get the Collider component
        unlockedlock.SetActive(false);
        if (unlockedKey != null)
        {
            unlockedKey.SetActive(false);
        }
        
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
                if (unlockedKey != null)
                {
                    unlockedKey.SetActive(true);
                    unlockedlock.SetActive(true);
                    lockedlock.SetActive(false);
                    gameObject.SetActive(false);

                    //animate drawer opening
                    cabinetAnimator.Play("unlockCabinet");

                    //play the illusion room animator rising

                    

                }
                
            }
        }
    }
}
