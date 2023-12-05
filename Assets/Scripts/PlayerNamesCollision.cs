using UnityEngine;
using TMPro;

public class PlayerNamesCollision : MonoBehaviour
{
    public TextMeshProUGUI textMeshProText;
    public AudioClip collisionSound;

    private int collisionCounter = 0;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            collisionCounter++;

            if (textMeshProText != null)
            {
                textMeshProText.text = "New Text On Trigger " + collisionCounter.ToString();
            }

            if (collisionSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }
        }
    }
}
