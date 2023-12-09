using UnityEngine;
using TMPro;
using Normal.Realtime;
public class PlayerNamesCollision : MonoBehaviour
{
    public TextMeshProUGUI textMeshProText;
    public AudioClip collisionSound;

    //private int collisionCounter = 0;
    private AudioSource audioSource;
    public Realtime realtime;

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
            //collisionCounter++;

            if (textMeshProText != null)
            {
                Debug.Log(realtime.clientID);
                textMeshProText.text = "Player Id " + realtime.clientID;
            }

            if (collisionSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }
        }
    }
}
