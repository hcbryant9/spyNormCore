
using UnityEngine;
using Normal.Realtime;
using UnityEngine.SceneManagement;

public class NormalSceneLoad : MonoBehaviour
{
    [SerializeField] private Realtime realtime;
    [SerializeField] private string roomName;
    [SerializeField] private int sceneIndex;

    private bool isLoading;

    public void LoadScene()
    {
        if (isLoading) return;
        isLoading = true;
        //disconnect from current room
        realtime.Disconnect();
        realtime = null;

        SceneManager.LoadScene(sceneIndex);

        realtime = FindObjectOfType<Realtime>();
        realtime.Connect(roomName);

        isLoading = false;
    }
}
