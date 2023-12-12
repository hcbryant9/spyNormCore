using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class ChangeAvatarCollision : MonoBehaviour
{
    //[SerializeField] private RealtimeAvatar localrealtimeAvatar;
    [SerializeField] private Realtime realtime;
    //public RealtimeAvatar changerealtimeAvatar;

    //object to change to
    public GameObject avatar1;
    public GameObject avatar2;

    //object 1 -> getting the children
    private GameObject oldAvatarHead1;
    private GameObject oldAvatarleftHand1;
    private GameObject oldAvatarrightHand1;

    private GameObject oldAvatarHead2;
    private GameObject oldAvatarleftHand2;
    private GameObject oldAvatarrightHand2;


    //object 2 -> getting the children
    private GameObject newAvatarHead1;
    private GameObject newAvatarleftHand1;
    private GameObject newAvatarrightHand1;
    private GameObject newAvatarbody1;

    private GameObject newAvatarHead2;
    private GameObject newAvatarleftHand2;
    private GameObject newAvatarrightHand2;
    private GameObject newAvatarbody2;


    private GameObject[] players;


    private bool canTrigger = true;
    private float lastTriggerTime = 0f;
    private float cooldownDuration = 5f; // 5 seconds cooldown

    private void Update()
    {
        /* 
        if (!findAvatar)
        {
            if (realtime.clientID == 0)
            {
                player = GameObject.Find("no shirt(Clone)");
                if (player != null)
                {
                    Debug.Log("calling the function");
                    ConfigurationofAvatar();
                    Debug.Log("found avatar for player with client id 0");
                    findAvatar = true; // Stop further updates
                }
            }
            else if (realtime.clientID == 1)
            {
                player = GameObject.Find("no shirt(Clone)");
                if (player != null)
                {
                    ConfigurationofAvatar();
                    Debug.Log("found avatar for player with client id 1");
                    findAvatar = true; // Stop further updates
                }
            }
            else if (realtime.clientID == 2)
            {
                findAvatar = true; // Stop further updates for client ID 2
            }

        }

         */
    }




    private void ConfigurationofAvatar()
    {
       
            //logic for player 0
            
            newAvatarHead1 = avatar1.transform.GetChild(0).gameObject;
            newAvatarleftHand1 = avatar1.transform.GetChild(1).gameObject;
            newAvatarrightHand1 = avatar1.transform.GetChild(2).gameObject;
            newAvatarbody1 = avatar1.transform.GetChild(3).gameObject;

            oldAvatarHead1 = players[0].transform.GetChild(0).gameObject;
            oldAvatarleftHand1 = players[0].transform.GetChild(1).gameObject;
            oldAvatarrightHand1 = players[0].transform.GetChild(2).gameObject;


            newAvatarHead1.transform.parent = oldAvatarHead1.transform;
            newAvatarleftHand1.transform.parent = oldAvatarleftHand1.transform;
            newAvatarrightHand1.transform.parent = oldAvatarrightHand1.transform;
            newAvatarbody1.transform.parent = players[0].transform;



            //logic for player 1 

            newAvatarHead2 = avatar2.transform.GetChild(0).gameObject;
            newAvatarleftHand2 = avatar2.transform.GetChild(1).gameObject;
            newAvatarrightHand2 = avatar2.transform.GetChild(2).gameObject;
            newAvatarbody2 = avatar2.transform.GetChild(3).gameObject;

            oldAvatarHead2 = players[1].transform.GetChild(0).gameObject;
            oldAvatarleftHand2 = players[1].transform.GetChild(1).gameObject;
            oldAvatarrightHand2 = players[1].transform.GetChild(2).gameObject;


            newAvatarHead2.transform.parent = oldAvatarHead2.transform;
            newAvatarleftHand2.transform.parent = oldAvatarleftHand2.transform;
            newAvatarrightHand2.transform.parent = oldAvatarrightHand2.transform;
            newAvatarbody2.transform.parent = players[1].transform;


        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand") && canTrigger)
        {
            if (Time.time - lastTriggerTime > cooldownDuration)
            {
                players = GameObject.FindGameObjectsWithTag("Player");
                Debug.Log("player at id 1" + players[1]);
                Debug.Log("player at id 0" + players[0]);
                if (players[0] != null && players[1] != null)
                {
                    Debug.Log("configuring!");
                    ConfigurationofAvatar();

                    // Update last trigger time and set canTrigger to false
                    lastTriggerTime = Time.time;
                    canTrigger = false;

                    // Start the cooldown timer
                    StartCoroutine(ActivateCooldown());
                }
            }
        }
    }
    // Cooldown timer to reset canTrigger after cooldownDuration
    private IEnumerator ActivateCooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);
        canTrigger = true;
    }
}