using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

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
    [SerializeField] private Realtime realtime;

    private void Start()
    {
        spyCamera.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hand") && canTrigger && realtime.clientID != 4) //check client id to see if it is camera guy
        {
            Debug.Log("Collision");
            canTrigger = false;
            spyCamera.SetActive(true);
        }
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Collision");
            canTrigger = false;
            spyCamera.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Collision");
            canTrigger = true;
            spyCamera.SetActive(false);
        }
    }
}
