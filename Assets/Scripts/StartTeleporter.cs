using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.SceneManagement;


public class StartTeleporter : MonoBehaviour
{

    //public AudioClip collisionSound;



    [SerializeField] private Realtime realtime;
    private int clientid;
    private bool isLoading;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {

            clientid = realtime.clientID;
            
            if (clientid == 0)
            {
                LoadScene("Room 1");
            } else if (clientid == 1)
            {
                LoadScene("Room 2");
            }
            else if (clientid == 2)
            {
                LoadScene("Room 3");
            } else if (clientid == 3)
            {
                LoadScene("Room 4");
            } else if (clientid == 4)
            {
                // camera man?
            }


        }
    }

    public void LoadScene(string scene)
    {
        if (isLoading) return;
        isLoading = true;
        //disconnect from current room
        realtime.Disconnect();
        realtime = null;

        SceneManager.LoadScene(scene);

        realtime = FindObjectOfType<Realtime>();
        realtime.Connect(scene);

        isLoading = false;
    }
}
