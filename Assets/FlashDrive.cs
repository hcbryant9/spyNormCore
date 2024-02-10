using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashDrive : MonoBehaviour
{
    private Transform driveTarget;
    private bool canTrigger = true;
    public GameObject drive; // this is a reference to where the other drive should appear.
    private Rigidbody rb;
    private Collider coll;

    public GameObject redLight; //light to rotate

    private bool buttonOnePressed = false;
    private void Start()
    {
        drive.SetActive(false);
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        coll = GetComponent<Collider>(); // Get the Collider component
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canTrigger && other.CompareTag("Hand"))
        {
            canTrigger = false;
            driveTarget = other.transform;
            rb.isKinematic = true;
            coll.enabled = false;
        }
    }


    private void Update()
    {
        if (!canTrigger && driveTarget != null)
        {
            // Follow the syringeTarget transform position
            transform.position = driveTarget.position;

            // Follow the syringeTarget transform rotation
            transform.rotation = driveTarget.rotation;

            // Check if Button One is pressed
            if (OVRInput.GetDown(OVRInput.Button.One) && !buttonOnePressed)
            {
                buttonOnePressed = true;

                // Hide the item
                gameObject.SetActive(false);
                drive.SetActive(true);

                // Rotate Light
                rotateLight();
                canTrigger = true;
            }
        }
    }
    void rotateLight()
    {
        // Check if the reference to the red light is valid
        if (redLight != null)
        {
            // Define the target rotation (rotate by -60 degrees in the y-axis)
            Quaternion targetRotation = Quaternion.Euler(redLight.transform.eulerAngles.x,
                                                         redLight.transform.eulerAngles.y - 60,
                                                         redLight.transform.eulerAngles.z);

            // Define the duration of rotation
            float duration = 0.5f; // Adjust the duration as per your preference

            // Store the initial rotation
            Quaternion startRotation = redLight.transform.rotation;

            // Start a coroutine for smooth rotation
            StartCoroutine(SmoothRotate(startRotation, targetRotation, duration));
        }
    }

    IEnumerator SmoothRotate(Quaternion startRotation, Quaternion targetRotation, float duration)
    {
        float elapsedTime = 0f;

        // Interpolate between the start and target rotations
        while (elapsedTime < duration)
        {
            redLight.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the final rotation is exactly the target rotation
        redLight.transform.rotation = targetRotation;
    }

}
