using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollection : MonoBehaviour
{
    public AudioController audioController;
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") && !triggered)
        {
            triggered = true;
            audioController.PlayHeadphones();
            Destroy(gameObject);
        }
    }
}
