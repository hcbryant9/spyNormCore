using UnityEngine;

public class BookTrigger : MonoBehaviour
{
    public Animator bookshelfAnimation;
    public Animator bookAnimation;

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
        if (bookshelfAnimation != null && bookAnimation !=null)
        {
            bookshelfAnimation.Play("Bookshelf_Move");
            bookAnimation.Play("BookPull");
        }
        else
        {
            Debug.Log("animator is null");
        }
    }
}
