using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSceneManager : MonoBehaviour
{
    public HandGestureController handGestureController;
    public GameObject pamphletCanvas;
    void Start()
    {
        if (handGestureController == null)
        {
            handGestureController = GetComponent<HandGestureController>();
            handGestureController.changeText("put on your headphones");
        }
        pamphletCanvas.SetActive(false);
    }
    public void headphonesOn()
    {
        handGestureController.changeText("open the briefcase");
        //play first audio
    }
   
    
    public void displayPamphlets()
    {
        StartCoroutine(DisplayPamphletCoroutine());
    }

    IEnumerator DisplayPamphletCoroutine()
    {
        pamphletCanvas.SetActive(true);
        yield return new WaitForSeconds(45f); // Display for 45 seconds
        pamphletCanvas.SetActive(false);
    }
}
