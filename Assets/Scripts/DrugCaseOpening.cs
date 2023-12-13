using UnityEngine;
using Normal.Realtime;
public class DrugCaseOpening : MonoBehaviour
{
    private Transform briefcaseLid; // Reference to the briefcase lid transform
    public float openingAngle = 90f; // Angle to open the briefcase
    public float openingSpeed = 2f; // Speed of the opening animation
    public AudioController audioController;

    public TrainSceneManager trainSceneManager;
    [SerializeField] private Realtime realtime;
    private bool isOpening = false;
    private bool hasBeenOpened = false;
    private Quaternion initialRotation;
    private Quaternion targetRotation;

    void Start()
    {
        briefcaseLid = this.gameObject.transform;
        initialRotation = briefcaseLid.rotation;
        targetRotation = initialRotation * Quaternion.Euler(0f, 0f, -openingAngle);
    }

    void Update()
    {
        if (isOpening)
        {
            // Calculate the delta rotation towards the target rotation
            Quaternion deltaRotation = Quaternion.RotateTowards(briefcaseLid.rotation, targetRotation, openingSpeed * Time.deltaTime);

            // Apply the delta rotation
            briefcaseLid.rotation = deltaRotation;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand") && !hasBeenOpened && realtime.clientID == 0 )
        {
            isOpening = true;
            audioController.PlayBriefcase();
            trainSceneManager.johnDialouge2();
            hasBeenOpened = true; // Set the flag to true once the briefcase is opened
        }
    }
}
