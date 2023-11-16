using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Make sure this variable is assigned in the Inspector

    void Start()
    {
        if (videoPlayer != null)
        {
            //videoPlayer.targetMaterialRenderer.material.mainTexture = GetComponent<Renderer>().material.mainTexture;
            videoPlayer.Play();
        }
        else
        {
            Debug.LogError("VideoPlayer component not assigned in the inspector.");
        }
    }
}
