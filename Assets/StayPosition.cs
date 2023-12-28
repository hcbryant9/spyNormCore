using UnityEngine;

public class StayAtPosition : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(-0.25f, -0.6f, -0.016f);

    void Update()
    {
        // Ensure the object stays at the target position
        transform.position = targetPosition;
    }
}
