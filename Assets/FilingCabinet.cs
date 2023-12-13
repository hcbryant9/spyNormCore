using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
public class FilingCabinet : MonoBehaviour
{


    [SerializeField] private Realtime realtime;
    public TrainSceneManager trainSceneManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            if (realtime.clientID == 0)
            {
                trainSceneManager.johnDialouge1();
            }
        }
    }

   
}
