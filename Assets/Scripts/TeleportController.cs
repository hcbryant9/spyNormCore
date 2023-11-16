using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class TeleportController : MonoBehaviour
{
    public XRController leftController;
    public XRController rightController;

    public InputHelpers.Button teleportRayButton;

    public float activationThreshold = 0.1f;

    private XRInteractorLineVisual leftRay;
    private GameObject leftRecticle;

    private XRInteractorLineVisual rightRay;
    private GameObject rightRecticle;

    void Start()
    {
        leftRay = leftController.gameObject.GetComponent<XRInteractorLineVisual>();
        leftRecticle = leftRay.reticle;

        rightRay = rightController.gameObject.GetComponent<XRInteractorLineVisual>();
        rightRecticle = rightRay.reticle;

    }
    void Update()
    {
        bool leftIsPressed = CheckIsButtonDown(leftController);
        leftRay.enabled = leftIsPressed;
        leftRecticle.SetActive(leftIsPressed);

        bool rightIsPressed = CheckIsButtonDown(rightController);
        rightRay.enabled = rightIsPressed;
        rightRecticle.SetActive(rightIsPressed);

    }
    public bool CheckIsButtonDown(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportRayButton, out bool isPressed, activationThreshold);
        return isPressed;
    }
}
