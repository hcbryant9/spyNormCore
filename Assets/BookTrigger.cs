using UnityEngine;

public class BookTrigger : MonoBehaviour
{
    public Animator bookshelfAnimation;
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
        if (bookshelfAnimation != null)
        {
            bookshelfAnimation.Play("Bookshelf_Move");
        }
    }
}
