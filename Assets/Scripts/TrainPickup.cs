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
            
            if (gameObject.CompareTag("Syringe"))
            {
                if(trainSceneManager.canPickUpSyringe == true)
                {
                    audioController.PlayHeadphones();
                    trainSceneManager.johnDialouge5();
                    gameObject.SetActive(false);
                }
                
            } else if (gameObject.CompareTag("Vial"))
            {
                audioController.PlayHeadphones();
                trainSceneManager.johnDialouge3();
                gameObject.SetActive(false);
            } else if (gameObject.CompareTag("BombMat"))
            {
                audioController.PlayHeadphones();
                gameObject.SetActive(false);
            } else if (gameObject.CompareTag("Paper"))
            {
                audioController.PlayHeadphones();
                trainSceneManager.pierreDialouge3();
                gameObject.SetActive(false);
            }
            
        }
        
    }


}
