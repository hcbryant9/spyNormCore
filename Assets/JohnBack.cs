using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class JohnBack : MonoBehaviour
{
    [SerializeField] private Realtime realtime;
    public TrainSceneManager trainSceneManager;
    private bool hasTriggered = false;
    private bool isCooldown = false;
    public GameObject syringeTarget;
    public AudioController audioController;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Syringe") && !hasTriggered && !isCooldown)
        {
            Debug.Log("instantiating new syringe in the back of ");
            audioController.Syringe();
            GameObject newSyringe = Realtime.Instantiate("Syringe", syringeTarget.transform.position, syringeTarget.transform.rotation);
            newSyringe.transform.parent = syringeTarget.transform;
            hasTriggered = true;
            StartCoroutine(StartCooldown());
            
        }
    }

    IEnumerator StartCooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(5f); // 5 seconds cooldown
        isCooldown = false;
        hasTriggered = false; // Reset trigger after cooldown
    }
}
