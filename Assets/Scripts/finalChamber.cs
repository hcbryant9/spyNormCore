using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalChamber : MonoBehaviour
{
    public GameObject final;
    void Start()
    {
        final.SetActive(false);
    }

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") && !triggered)
        {
            final.SetActive(true);
            triggered = true;
            
        }
    }

}
