using UnityEngine;

public class CameraController : MonoBehaviour
{
    WebCamTexture webcamTexture;

    void Start()
    {
        webcamTexture = new WebCamTexture();
        if (webcamTexture != null)
        {
            GetComponent<Renderer>().material.mainTexture = webcamTexture;
            webcamTexture.Play();
        }
        
    }
}
