using System.Collections;
using UnityEngine;

public class FinalDestruction : MonoBehaviour
{
    public Material material1; // Assign these in the Unity Editor
    public Material material2;
    public GameObject finalDome; // assign the final room here
    public Animator popAnim; //put animator for pop here
    public Animator fallAnim; //put animator for falling here
    private Renderer rend;
    private bool canTrigger = true;
    private bool isMaterial1 = true;
    private int swapCount = 0;
    private int maxSwaps = 4; // Define the maximum number of swaps here

    private void Start()
    {
        rend = finalDome.GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canTrigger && other.CompareTag("Hand"))
        {
            canTrigger = false;
        }
    }

    private void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Two))
        {
            if (isMaterial1)
            {
                rend.material = material2;
                swapCount++;
            }
            else
            {
                rend.material = material1;
                swapCount++;
            }

            if (swapCount >= maxSwaps)
            {
                //play pop animation and box falling
                rend.material = material1;
                StartCoroutine(WaitAndPlayAnimation(3f)); // Wait for 3 seconds and then play the animation
            }
        }
    }

    private IEnumerator WaitAndPlayAnimation(float duration)
    {
        yield return new WaitForSeconds(duration);
        popAnim.Play("popAnim");
        fallAnim.Play("fallAnim");
    }
}
