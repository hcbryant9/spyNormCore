using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightBlinker : MonoBehaviour
{
    private bool canTrigger = true;
    private float lastTriggerTime = 0f;
    private float cooldownDuration = 5f; // 5 seconds cooldown
    private bool on = true;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (canTrigger)
            {
                if(on){
                    gameObject.SetActive(true);

                } else{
                    gameObject.SetActive(false);
                }
                if (Time.time - lastTriggerTime > cooldownDuration)
                {
                    // Update last trigger time and set canTrigger to false
                    lastTriggerTime = Time.time;
                    canTrigger = false;

                    // Start the cooldown timer
                    StartCoroutine(ActivateCooldown());
                }
            }
    }
    private IEnumerator ActivateCooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);
        on = false;
        canTrigger = !canTrigger;
    }
}
