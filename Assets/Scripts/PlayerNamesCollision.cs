using UnityEngine;
using TMPro;

public class PlayerNamesCollision : MonoBehaviour
{
    public TextMeshProUGUI textMeshProText;
    public string newTextOnTrigger = "New Text On Trigger";

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            if (textMeshProText != null)
            {
                textMeshProText.text = newTextOnTrigger;
            }
        }
    }
}
