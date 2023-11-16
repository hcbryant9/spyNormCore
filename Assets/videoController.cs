using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.targetMaterialRenderer.material.mainTexture = GetComponent<Renderer>().material.mainTexture;
        videoPlayer.Play();
    }
}
