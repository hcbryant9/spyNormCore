using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.SceneManagement;


public class StartTeleporter : MonoBehaviour
{
    
    //public AudioClip collisionSound;


    
    public Realtime realtime;
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

    IEnumerator LoadSceneAsync(string scene)
    {
        realtime.Disconnect();
        realtime = null;

        var loadAsync = SceneManager.LoadSceneAsync(realtime.clientID + 1);

        //wait for it to finish
        while (!loadAsync.isDone) yield return null;

        realtime.Connect(scene);
        isLoading = false;
    }
    private void LoadScene(string scene)
    {
        if (isLoading) return;
        isLoading = true;

        StartCoroutine(LoadSceneAsync(scene));

    }
}
