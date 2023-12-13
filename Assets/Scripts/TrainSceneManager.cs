using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;


public class TrainSceneManager : MonoBehaviour
{
    [SerializeField] private Realtime realtime;

    public bool canPickUpSyringe = false;

    public void startDialouge()
    {
        if (realtime.clientID == 0)
        {
            //“Alright. The office is upstairs, in the middle of the lounge. It’s used by executives when riding the train, and is the perfect place to plant the evidence. Find a filing cabinet in there, and don’t be seen!

            //“Remember, you are John Wood. Sell yourself!”
        } else if (realtime.clientID == 1)
        {
            //message from helios to pierre goes here.f
            //?
        }
    }
    public void johnDialouge1()
    {
        //“Great work, Wood. Now take that key down to the storage room. It’s behind the east staircase.”
    }
    public void johnDialouge2()
    {
        //Look. At. All. Those. Drugs! It’s not for you, buddy. You are gonna drug Pierre! Up in the lounge, you can poison his drink. With one of those vials. Make him look stupid.”

        //“No time to lose, get up there!”
    }
   
    public void johnDialouge3()
    {
        //“Now go sneak the vial into Pierre’s glass.”
        //Pierre is at the bar
    }
    public void johnDialouge4()
    {
        //“That didn’t work. Shit. John, I was hoping we weren’t gonna have to do this, but back down in the Lucidity case, there are syringes. You’re gonna have to stab him.”
    }
    public void johnDialouge5()
    {
        //“[sigh], okay.Just make this is seamless as possible.Pretend to bump into him or something. This isn’t ideal, I know, but we have to do something.Higher ups need Bourgeois to look like a junkie. Or just crazy.It’s imperative that he looks stupid.”
    }
}
