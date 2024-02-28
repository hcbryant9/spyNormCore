using UnityEngine;
using UnityEngine.XR;

public class DeviceManager : MonoBehaviour
{
    private bool _isComputer = false;

    // Reference to the target GameObject to teleport to
    public Transform teleportTarget;

    public SimpleMove simpleMove;
    public OVRPlayerController ovrPlayerController;

    
    void Start()
    {
        // Check if XR settings are supported
        if (XRSettings.isDeviceActive)
        {
            // XR device is active, meaning the player is using a VR device
            Debug.Log("VR Device Detected: " + XRSettings.loadedDeviceName);
            _isComputer = false;
            ovrPlayerController.enabled = true;
            simpleMove.enabled = false;
            ovrPlayerController.SetMoveScaleMultiplier(.2f);
        }
        else
        {
            // No XR device active, the player is on a standard computer
            Debug.Log("No VR Device Detected. Standard Computer.");
            _isComputer = true;
            ovrPlayerController.enabled = false;
            simpleMove.enabled = true;
            
        }
    }

    void Update()
    {
        if (_isComputer)
        {
            // Check for left mouse click
            if (Input.GetMouseButtonDown(0))
            {
                // Teleport the player to the location of the teleport target
                TeleportPlayer();
            }
        }
        if (!_isComputer)
        {
            if (OVRInput.Get(OVRInput.Button.Four))
            {
                ovrPlayerController.SetMoveScaleMultiplier(.5f);
            } else if (OVRInput.Get(OVRInput.Button.Three))
            {
                ovrPlayerController.SetMoveScaleMultiplier(.2f);
            }
        }
    }

    void TeleportPlayer()
    {
        if (teleportTarget != null)
        {
            // Move the player to the position of the teleport target
            transform.position = teleportTarget.position;
            Debug.Log("Player teleported to: " + teleportTarget.name);
        }
        else
        {
            Debug.LogWarning("No teleport target assigned in the inspector.");
        }
    }
}
