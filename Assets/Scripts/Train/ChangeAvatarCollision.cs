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
    public GameObject avatar3;
    public GameObject avatar4;
    
    //object 3 -> getting the children
    

    

    
     




    //object 1 -> getting the children
    private GameObject oldAvatarHead1;
    private GameObject oldAvatarleftHand1;
    private GameObject oldAvatarrightHand1;

    private GameObject oldAvatarHead2;
    private GameObject oldAvatarleftHand2;
    private GameObject oldAvatarrightHand2;

    private GameObject oldAvatarHead3;
    private GameObject oldAvatarleftHand3;
    private GameObject oldAvatarrightHand3;

    private GameObject oldAvatarHead4;
    private GameObject oldAvatarleftHand4;
    private GameObject oldAvatarrightHand4;

    //object 2 -> getting the children
    private GameObject newAvatarHead1;
    private GameObject newAvatarleftHand1;
    private GameObject newAvatarrightHand1;
    private GameObject newAvatarbody1;

    private GameObject newAvatarHead2;
    private GameObject newAvatarleftHand2;
    private GameObject newAvatarrightHand2;
    private GameObject newAvatarbody2;

    private GameObject newAvatarHead3;
    private GameObject newAvatarleftHand3;
    private GameObject newAvatarrightHand3;
    private GameObject newAvatarbody3;

    private GameObject newAvatarHead4;
    private GameObject newAvatarleftHand4;
    private GameObject newAvatarrightHand4;
    private GameObject newAvatarbody4;

    //array to hold all players with tag "player"
    private GameObject[] players;


    private bool canTrigger = true;
    private float lastTriggerTime = 0f;
    private float cooldownDuration = 5f; // 5 seconds cooldown

    



    public void ConfigurationofAvatar()
    {
       
            //logic for player 1
            
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



            //logic for player 2 

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

            

            //logic for player 3


            newAvatarHead3 = avatar3.transform.GetChild(0).gameObject;
            newAvatarleftHand3 = avatar3.transform.GetChild(1).gameObject;
            newAvatarrightHand3 = avatar3.transform.GetChild(2).gameObject;
            newAvatarbody3 = avatar3.transform.GetChild(3).gameObject;

            oldAvatarHead3 = players[2].transform.GetChild(0).gameObject;
            oldAvatarleftHand3 = players[2].transform.GetChild(1).gameObject;
            oldAvatarrightHand3 = players[2].transform.GetChild(2).gameObject;


            newAvatarHead3.transform.parent = oldAvatarHead3.transform;
            newAvatarleftHand3.transform.parent = oldAvatarleftHand3.transform;
            newAvatarrightHand3.transform.parent = oldAvatarrightHand3.transform;
            newAvatarbody3.transform.parent = players[2].transform;



            //logic for player 4

            newAvatarHead4 = avatar4.transform.GetChild(0).gameObject;
            newAvatarleftHand4 = avatar4.transform.GetChild(1).gameObject;
            newAvatarrightHand4 = avatar4.transform.GetChild(2).gameObject;
            newAvatarbody4 = avatar4.transform.GetChild(3).gameObject;

            oldAvatarHead4 = players[3].transform.GetChild(0).gameObject;
            oldAvatarleftHand4 = players[3].transform.GetChild(1).gameObject;
            oldAvatarrightHand4 = players[3].transform.GetChild(2).gameObject;


            newAvatarHead4.transform.parent = oldAvatarHead4.transform;
            newAvatarleftHand4.transform.parent = oldAvatarleftHand4.transform;
            newAvatarrightHand4.transform.parent = oldAvatarrightHand4.transform;
            newAvatarbody4.transform.parent = players[3].transform;

         

    }
    private void ConfigurationofAvatarOne()
    {
        //logic for player 1

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

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand") && canTrigger)
        {
            if (Time.time - lastTriggerTime > cooldownDuration)
            {
                players = GameObject.FindGameObjectsWithTag("Player");
                Debug.Log("player at id 3" + players[3]);
                Debug.Log("player at id 2" + players[2]);
                Debug.Log("player at id 1" + players[1]);
                Debug.Log("player at id 0" + players[0]);
                if (players[0] != null && players[1] != null && players[2] != null && players[3] != null)
                {
                    Debug.Log("configuring!");
                    ConfigurationofAvatar();

                    // Update last trigger time and set canTrigger to false
                    lastTriggerTime = Time.time;
                    canTrigger = false;

                    // Start the cooldown timer
                    StartCoroutine(ActivateCooldown());
                } else if (players[0] != null)
                {
                    Debug.Log("configuring player ONE ONLY!");
                    ConfigurationofAvatarOne();

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