using UnityEngine;

public class TextInteractionZone : MonoBehaviour
{
    public GameObject text;

    private void Start()
    {
        text.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Hand"))
        {
            // Activate checklist canvas
            text.SetActive(true);
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
     
        if (other.gameObject.CompareTag("Hand"))
        {
            // Deactivate checklist canvas
            text.SetActive(false);
        }
    }
}
