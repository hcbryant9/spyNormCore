using UnityEngine;

public class LockScale : MonoBehaviour
{
    public Vector3 lockedScale = new Vector3(1f, 1f, 1f); // Set the desired locked scale

    void Update()
    {
        // Ensure that the scale remains locked
        transform.localScale = lockedScale;
    }
}
