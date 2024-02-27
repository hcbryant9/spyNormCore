using UnityEngine;
using Normal.Realtime;
using System.Collections.Generic;
public class openDoor : MonoBehaviour
{
    public AudioController audioController; // reference to audio manager


    private bool hasTriggered = false;
    private bool isDoorOpen = false;
    private bool closed = true;
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
                hasTriggered = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand") && !hasTriggered)
        {
            hasTriggered = true; 
            if (!closed)
            {
                if (audioController != null)
                {
                    if (gameObject.CompareTag("BigDoor"))
                    {
                        //play the door close sfx
                        audioController.PlayClose();
                    }
                    else
                    {
                        //play the door close sfx 
                        audioController.PlayClose();
                    }

                }
                else
                {
                    Debug.Log("audio controller on door is not attached genius");
                }
                Debug.Log("closing door");
                Invoke("CloseDoor", 2.0f);

            }
            else
            {
                if (audioController != null)
                {
                    if (gameObject.CompareTag("BigDoor"))
                    {
                        //play the big door sfx
                        audioController.PlayBigDoor();
                    }
                    else
                    {
                        //play the small door sfx
                        audioController.PlayDoor();
                    }

                }
                else
                {
                    Debug.Log("audio controller on door is not attached genius");
                }
                Debug.Log("Opening door");
                Invoke("OpenDoor", 2.0f);
            }
        }
    }

    private void OpenDoor()
    {
        if (!isDoorOpen)
        {
            isDoorOpen = true;
            // Set the target rotation to open position
            targetRotation = initialRotation * Quaternion.Euler(0, -90, 0);
            closed = false;
        }
    }

    private void CloseDoor()
    {
        if (!isDoorOpen)
        {
            isDoorOpen = true;
            // Set the target rotation to the initial position
            targetRotation = initialRotation;
            closed = true;
        }
    }
}
