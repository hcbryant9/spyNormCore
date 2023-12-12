using UnityEngine;
using TMPro;
public class HandGestureController : MonoBehaviour
{
    public GameObject checklistCanvas;
    public TextMeshProUGUI textMeshProText;
    // Threshold for determining if the hand is facing up (close to 180 in Z rotation)
    public float upRotationThreshold = 10f; // Adjust as needed

    // Update is called once per frame
    void Start()
    {
        checklistCanvas.SetActive(false);
        changeText("open the brief case");
    }
    void Update()
    {
        // Check the rotation of the GameObject (hand representation)
        float handRotationZ = transform.rotation.eulerAngles.z;

        // Check if the hand rotation is close to 180 in the Z-axis
        if (IsHandFacingUp(handRotationZ))
        {
            // Activate checklist canvas
            checklistCanvas.SetActive(true);
        }
        else
        {
            // Deactivate checklist canvas if hand gesture is not recognized
            checklistCanvas.SetActive(false);
        }
    }

    bool IsHandFacingUp(float rotationZ)
    {
        // Check if the rotation indicates the hand is facing up
        return Mathf.Abs(rotationZ - 180f) < upRotationThreshold;
    }
    public void changeText(string text)
    {
        if (textMeshProText != null)
        {
            textMeshProText.text = " ";
            textMeshProText.text = text;
        }
       
    }
}
