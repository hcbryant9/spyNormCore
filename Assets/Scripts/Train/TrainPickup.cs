using UnityEngine;
using System.Collections;
using Normal.Realtime;

public class TrainPickup : MonoBehaviour
{
    public bool shouldCollect = true; // Boolean to define if the object should be collected
    public AudioController audioController;
    public TrainSceneManager trainSceneManager;
    //public GameObject book;
    public GameObject syringeTarget;
    //public GameObject bomb;
    void OnTriggerEnter(Collider other)
    {
        if (gameObject.activeSelf && other.gameObject.CompareTag("Hand"))
        {
            Debug.Log("Collision occurred");
            Collect();

        }
    }
    private void Start()
    {
        //bomb.SetActive(false);
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
                    //instantiate realtime object on the hand of pierre
                    Debug.Log("instantiating syringe");
                    GameObject newSyringe = Realtime.Instantiate("Syringe", syringeTarget.transform.position, syringeTarget.transform.rotation);
                    newSyringe.transform.parent = syringeTarget.transform;

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
