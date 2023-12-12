using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class teleportAvatarStart : MonoBehaviour
{
    [SerializeField] private Realtime realtime;
    public Transform Player1Teleportation;
    public Transform Player2Teleportation;
    public GameObject player;
    public TrainSceneManager trainSceneManager;
    
    private bool hasTeleported = false;

    void OnTriggerEnter(Collider other)
    {
        if (hasTeleported) // Check if teleportation has already occurred
        {
            return; // Exit the function if already teleported
        }

        if (other.gameObject.CompareTag("Hand"))
        {
            if (realtime.clientID == 0)
            {
                // Teleport player 1 to Player1Teleportation position
                if (player != null && Player1Teleportation != null)
                {
                    player.transform.position = Player1Teleportation.position;
                    hasTeleported = true; // Set the flag to true after teleportation
                    trainSceneManager.startDialouge();
                    
                }
            }
            else if (realtime.clientID == 1)
            {
                // Teleport player 2 to Player2Teleportation position
                if (player != null && Player2Teleportation != null)
                {
                    player.transform.position = Player2Teleportation.position;
                    hasTeleported = true; // Set the flag to true after teleportation
                    
                }
            }
        }
    }
}
