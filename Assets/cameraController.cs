using UnityEngine;

public class CameraController : MonoBehaviour
{
    WebCamTexture webcamTexture;

    void Start()
    {
        webcamTexture = new WebCamTexture();
        GetComponent<Renderer>().material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }
}
