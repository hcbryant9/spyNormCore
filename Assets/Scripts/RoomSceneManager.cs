using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSceneManager : MonoBehaviour
{
    private HandGestureController handGestureController;
    public GameObject pamphletCanvas;
    private StartTeleporter startTeleporter;

    private bool canLeave = false;
    void Start()
    {
      
        handGestureController = GetComponent<HandGestureController>();
        handGestureController.changeText("put on your headphones");
        pamphletCanvas.SetActive(false);
        startTeleporter = GetComponent<StartTeleporter>();
    }
    public void headphonesOn()
    {
        handGestureController.changeText("open the briefcase");
        //play first audio
    }
   
    public void doorKnobOpen()
    {
        if (canLeave)
        {
            startTeleporter.LoadScene("Lobby");
        }
        
    }
    public void displayPamphlets()
    {
        StartCoroutine(DisplayPamphletCoroutine());
        handGestureController.changeText("open the door");
    }

    IEnumerator DisplayPamphletCoroutine()
    {
        pamphletCanvas.SetActive(true);
        yield return new WaitForSeconds(100f); // Display for 45 seconds
        canLeave = true;
        pamphletCanvas.SetActive(false);
    }
}
