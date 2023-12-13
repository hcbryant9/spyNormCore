using UnityEngine;
using System.Collections;

public class TrainPickup : MonoBehaviour
{
    public bool shouldCollect = true; // Boolean to define if the object should be collected
    public AudioController audioController;
    public TrainSceneManager trainSceneManager;


    void OnTriggerEnter(Collider other)
    {
        if (gameObject.activeSelf && other.gameObject.CompareTag("Hand"))
        {
            Debug.Log("Collision occurred");
            Collect();

        }
    }

    void Collect()
    {
        if (gameObject.activeSelf && shouldCollect)
        {
            if (audioController != null)
            {


                audioController.PlayHeadphones();

            }
            else
            {
                Debug.Log("audio controller is null");
            }
            if (gameObject.CompareTag("Syringe"))
            {
                audioController.PlayHeadphones();
                trainSceneManager.syringePickup();
            } else if (gameObject.CompareTag("Vial"))
            {
                audioController.PlayHeadphones();
                trainSceneManager.vialPickup();
            }
            gameObject.SetActive(false);
        }
        
    }


}
