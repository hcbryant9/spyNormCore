using UnityEngine;
using Normal.Realtime;

public class openDoor : MonoBehaviour
{
    public AudioController audioController; // reference to audio manager
    

    private bool hasTriggered = false;
    private bool isDoorOpen = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private float openSpeed = 90.0f; // Adjust the speed of door opening

    private void Start()
    {
        initialRotation = gameObject.transform.rotation;
        targetRotation = initialRotation * Quaternion.Euler(0, -90, 0); // Rotate -90 degrees from initial rotation
        
    }

    private void Update()
    {
        if (isDoorOpen)
        {
            // Gradually rotate the door towards the target rotation
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, targetRotation, openSpeed * Time.deltaTime);

            // Check if the door has reached the target rotation
            if (Quaternion.Angle(gameObject.transform.rotation, targetRotation) < 0.1f)
            {
                isDoorOpen = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand") && !hasTriggered)
        {
            if(audioController != null)
            {
                if (gameObject.CompareTag("BigDoor"))
                {
                    //play the big door sfx
                }
                else
                {
                    //play the small door sfx
                    audioController.PlayDoor();
                }
                
            } else
            {
                Debug.Log("audio controller on door is not attached genius");
            }
            
            hasTriggered = true; // Set the flag to true to indicate the event has occurred
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        if (!isDoorOpen)
        {
            isDoorOpen = true;
            // You can add any additional actions or animations related to opening the door here
        }
    }
}
