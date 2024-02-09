using UnityEngine;

public class cabinet : MonoBehaviour
{
    public Animator animator;
    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") && !triggered)
        {
            Debug.Log("Playing animation");
            triggered = true;
            PlayCabinetAnimation();
        }
    }

    private void PlayCabinetAnimation()
    {
        if (animator != null)
        {
            animator.Play("cabinetAnim");
        } else
        {
            Debug.Log("animation is null");
        }
        
    }
}
