using UnityEngine;
using Normal.Realtime;

public class DrugBeer : MonoBehaviour
{
    public AudioController audioController;
    public TrainSceneManager trainSceneManager;
    public Transform beerPoint;
    public string beerName;
    [SerializeField] private Realtime realtime;

    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand") && !hasTriggered)
        {
            if (realtime.clientID == 0)
            {
                Debug.Log("Instantiating: " + beerName);
                audioController.PlayBeverage();
                Realtime.Instantiate(beerName, beerPoint.position, beerPoint.rotation);
                trainSceneManager.johnDialouge4();
                hasTriggered = true; // Set the flag to true to indicate the event has occurred
            }
        }
    }
}
