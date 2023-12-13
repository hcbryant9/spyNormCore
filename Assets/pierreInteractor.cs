using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class pierreInteractor : MonoBehaviour
{
    [SerializeField] private Realtime realtime;
    public TrainSceneManager trainSceneManager;
    private bool hasTriggered = false;
    private bool isCooldown = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand") && !hasTriggered && !isCooldown)
        {
            if (realtime.clientID == 1)
            {
                if (trainSceneManager.hasBlueprints == true)
                {
                    trainSceneManager.pierreDialouge4();
                }
                else
                {
                    trainSceneManager.pierreDialouge2();
                }

                hasTriggered = true;
                StartCoroutine(StartCooldown());
            }
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
