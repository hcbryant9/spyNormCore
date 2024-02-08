using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCamera : MonoBehaviour
{
    /* 
     *This script is for the player to plant cameras around the map
     *Whatever this script is attached to you need a rigid body & box collider
     *There should also be an attached object that will be hidden at start and then when collided with -> the object gets set visible again
     *
     *
     *hb
     */
    private bool canTrigger = true;
    public GameObject spyCamera;


    private void Start()
    {
        spyCamera.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hand") && canTrigger)
        {
            Debug.Log("Collision");
            canTrigger = false;
            spyCamera.SetActive(true);
        }
        
    }
}
