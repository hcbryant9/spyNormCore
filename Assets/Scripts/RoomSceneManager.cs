using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSceneManager : MonoBehaviour
{
    public HandGestureController handGestureController;

    void Start()
    {
        if (handGestureController == null)
        {
            handGestureController = GetComponent<HandGestureController>();
            handGestureController.changeText("put on your headphones");
        }
    }
    public void headphonesOn()
    {
        handGestureController.changeText("open the briefcase");
        //play first audio
    }
   
}
