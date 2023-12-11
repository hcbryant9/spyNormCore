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
    private GameObject oldAvatarHead;
    private GameObject oldAvatarleftHand;
    private GameObject oldAvatarrightHand;
    

    //object 2 -> getting the children
    private GameObject newAvatarHead;
    private GameObject newAvatarleftHand;
    private GameObject newAvatarrightHand;
    private GameObject newAvatarbody;

    bool findAvatar = false;
    [SerializeField]private GameObject player;


    private void Update()
    {
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
    }




    private void ConfigurationofAvatar()
    {
        if (realtime.clientID == 0)
        {
            //player 1
            player = GameObject.Find("no shirt(Clone)");

            //get references to avatar 1
            newAvatarHead = avatar1.transform.GetChild(0).gameObject;
            newAvatarleftHand = avatar1.transform.GetChild(1).gameObject;
            newAvatarrightHand = avatar1.transform.GetChild(2).gameObject;
            newAvatarbody = avatar1.transform.GetChild(3).gameObject;
            player.name = "player1";
        }
        else if (realtime.clientID == 1)
        {
            //player 2
            player = GameObject.Find("no shirt(Clone)");

            //get references to avatar 2
            newAvatarHead = avatar2.transform.GetChild(0).gameObject;
            newAvatarleftHand = avatar2.transform.GetChild(1).gameObject;
            newAvatarrightHand = avatar2.transform.GetChild(2).gameObject;
            newAvatarbody = avatar2.transform.GetChild(3).gameObject;
            player.name = "player2";
        }
        else
        {
            //any other players
        }
        //these objects are the default avatars head , left hand, and right hand
        //they will be used as a target for the player's new avatar to be the parent
        oldAvatarHead = player.transform.GetChild(0).gameObject;
        oldAvatarleftHand = player.transform.GetChild(1).gameObject;
        oldAvatarrightHand = player.transform.GetChild(2).gameObject;


        //making the new head, lefthand, and right hand children of the parents in the avatar
        newAvatarHead.transform.parent = oldAvatarHead.transform;
        newAvatarleftHand.transform.parent = oldAvatarleftHand.transform;
        newAvatarrightHand.transform.parent = oldAvatarrightHand.transform;
        newAvatarbody.transform.parent = player.transform;
    }

    
}