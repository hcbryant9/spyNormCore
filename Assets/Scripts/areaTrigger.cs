using UnityEngine;

public class AreaTrigger : MonoBehaviour
{
    
    public GameObject imageRotator;
    public float rotationSpeed = 90f; // degrees per second

    private bool inArea;
    private bool isRotating = false;
    private Quaternion targetRotation;

    private void Start()
    {
        imageRotator.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            inArea = true;
            //imageRotator.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            imageRotator.SetActive(false);
        }
    }

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One) && inArea && !isRotating)
        {
            // Calculate the target rotation (add 180 degrees to the current rotation)
            targetRotation = imageRotator.transform.rotation * Quaternion.Euler(0f, 180f, 0f);
            isRotating = true; // Start rotating
        }

        if (isRotating)
        {
            // Rotate towards the target rotation
            imageRotator.transform.rotation = Quaternion.RotateTowards(imageRotator.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Check if we've reached the target rotation
            if (Quaternion.Angle(imageRotator.transform.rotation, targetRotation) < 0.01f)
            {
                imageRotator.transform.rotation = targetRotation; // Snap to the exact target rotation
                isRotating = false; // Stop rotating
            }
        }
    }
}
