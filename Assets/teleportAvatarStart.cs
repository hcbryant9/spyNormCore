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

    public GameObject player1lefthand;
    public GameObject player1righthand;

    public GameObject player2lefthand;
    public GameObject player2righthand;
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
                    player1lefthand.SetActive(false);
                    player1righthand.SetActive(false);
                    player2lefthand.SetActive(false);
                    player2righthand.SetActive(false);
                }
            }
            else if (realtime.clientID == 1)
            {
                // Teleport player 2 to Player2Teleportation position
                if (player != null && Player2Teleportation != null)
                {
                    player.transform.position = Player2Teleportation.position;
                    hasTeleported = true; // Set the flag to true after teleportation
                    player1lefthand.SetActive(false);
                    player1righthand.SetActive(false);
                    player2lefthand.SetActive(false);
                    player2righthand.SetActive(false);
                }
            }
        }
    }
}
