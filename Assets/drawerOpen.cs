using UnityEngine;

public class drawerOpen : MonoBehaviour
{
   
    public float rotationSpeed = 90f; // degrees per second

    private bool triggered = false;
    private Quaternion targetRotation;
    private bool isRotating = false;

   

    void Update()
    {
        if (isRotating)
        {
            // Rotate towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Check if we've reached the target rotation
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.01f)
            {
                transform.rotation = targetRotation; // Snap to the exact target rotation
                isRotating = false; // Stop rotating
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") && !triggered)
        {
            
            Rotate90Degrees(); // Rotate the object when the hand enters
            triggered = true;
        }
    }

    private void Rotate90Degrees()
    {
        if (!isRotating)
        {
            // Calculate the target rotation (add 90 degrees to the current rotation)
            targetRotation = transform.rotation * Quaternion.Euler(0f, 90f, 0f);
            isRotating = true; // Start rotating
        }
    }
}
