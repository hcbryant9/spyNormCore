using UnityEngine;

public class BookTrigger : MonoBehaviour
{
    public Animator bookshelfAnimation; //reference to bookshelf sliding animation
    public Animator bookAnimation; //reference to book sliding out animation
    public AudioController audioController; // reference to audio manager
    private bool triggered = false;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") && !triggered)
        {
            triggered = true;
            PlayBookshelfAnimation();
        }
    }

    private void PlayBookshelfAnimation()
    {
        if (bookshelfAnimation != null && bookAnimation != null && audioController != null )
        {
            audioController.PlayBookshelf();
            bookshelfAnimation.Play("Bookshelf_Move");
            bookAnimation.Play("BookPull");
        }
        else
        {
            Debug.Log("animator is null");
        }
    }
}
