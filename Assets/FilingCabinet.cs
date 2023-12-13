using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
public class FilingCabinet : MonoBehaviour
{


    [SerializeField] private Realtime realtime;
    public TrainSceneManager trainSceneManager;
    public AudioController audioController;

    public GameObject paper;

    private void Start()
    {
        paper.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            if (realtime.clientID == 0)
            {
                paper.SetActive(true);
                audioController.PlayHeadphones();
                trainSceneManager.johnDialouge1();
            }
        }
    }

   
}
