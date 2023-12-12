using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;


public class TrainSceneManager : MonoBehaviour
{
    [SerializeField] private Realtime realtime;
    
    void Start()
    {
        
    }

    // Update is called once per frameff
    void Update()
    {
        
    }

    public void startDialouge()
    {
        if (realtime.clientID == 0)
        {
            //“Alright. The office is upstairs, in the middle of the lounge. It’s used by executives when riding the train, and is the perfect place to plant the evidence. Find a filing cabinet in there, and don’t be seen!

            //“Remember, you are John Wood. Sell yourself!”
        } else if (realtime.clientID == 1)
        {
            //message from helios to pierre goes here.
            //?
        }
    }
    public void johnDialouge()
    {
        //“Great work, Wood. Now take that key down to the storage room. It’s behind the east staircase.”
    }
}
