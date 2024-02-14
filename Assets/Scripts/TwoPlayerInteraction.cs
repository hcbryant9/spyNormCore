using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class TwoPlayerInteraction : MonoBehaviour
{
    
    private bool canTrigger = true;
    private float lastTriggerTime = 0f;
    private float cooldownDuration = 5f; // 5 seconds cooldown

    public GameObject door; //reference to the door
    

    private bool canPlayAnimation = true;

    // HashSet to store references to unique Hand objects inside the trigger zone
    private HashSet<GameObject> handsInside = new HashSet<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is tagged as "Hand" and if it's not already in the HashSet
        if (other.gameObject.CompareTag("Hand") && !handsInside.Contains(other.gameObject) && canPlayAnimation)
        {
            // Add the Hand object to the HashSet
            handsInside.Add(other.gameObject);

            // Check if enough unique Hand objects are inside and the trigger can be activated
            if (handsInside.Count >= 6 && canTrigger)
            {

                door.SetActive(false);


                canPlayAnimation = false;
                
                if (Time.time - lastTriggerTime > cooldownDuration)
                {
                    // Update last trigger time and set canTrigger to false
                    lastTriggerTime = Time.time;
                    canTrigger = false;

                    // Start the cooldown timer
                    StartCoroutine(ActivateCooldown());
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Check if the collider is tagged as "Hand" and if it's in the HashSet
        if (other.gameObject.CompareTag("Hand") && handsInside.Contains(other.gameObject))
        {
            // Remove the Hand object from the HashSet
            handsInside.Remove(other.gameObject);
        }
    }

    // Cooldown timer to reset canTrigger after cooldownDuration
    private IEnumerator ActivateCooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);
        canTrigger = true;
    }
}
