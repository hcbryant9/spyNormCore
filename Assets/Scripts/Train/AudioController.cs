using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource playerAudioSource;
    public AudioClip headphones;
    public AudioClip briefcase;
    public AudioClip beverage;
    public AudioClip syringe;
    public AudioClip door;
    public AudioClip bookshelf;
    public AudioClip bigdoor;
    public AudioClip cabinet;
    void Start()
    {


        playerAudioSource = GetComponent<AudioSource>();


    }

    // Function to play a sound through the player's AudioSource
    public void PlaySound(AudioClip clip)
    {
        if (clip != null && playerAudioSource != null)
        {
            playerAudioSource.clip = clip;
            playerAudioSource.Play();
        }
        else
        {
            if (clip == null)
            {
                Debug.Log("the clip is null");
            }
            else
            {
                Debug.Log("the source is null");
            }
        }
    }

    // You can add more functions here for different sound effects or actions
    // For instance:
    public void PlayHeadphones()
    {
        if (headphones != null)
        {
            PlaySound(headphones);
        }
        else
        {
            Debug.Log("headphones is null");
        }
    }
    public void PlayBriefcase()
    {
        if (briefcase != null)
        {
            PlaySound(briefcase);
        }
        else
        {
            Debug.Log("briefcase is null");
        }
    }
    public void PlayBeverage()
    {
        if (beverage != null)
        {
            PlaySound(beverage);
        }
        else
        {
            Debug.Log("beverage is null");
        }

    }
    public void PlaySyringe()
    {
        if (beverage != null)
        {
            PlaySound(syringe);
        }
        else
        {
            Debug.Log("beverage is null");
        }
    }
    public void PlayDoor()
    {
        if (beverage != null)
        {
            PlaySound(door);
        }
        else
        {
            Debug.Log("door is null");
        }
    }
    public void PlayBookshelf()
    {
        if(bookshelf!= null)
        {
            PlaySound(bookshelf);
        }
        else
        {
            Debug.Log("bookshelf is null");
        }
    }
    public void PlayBigDoor()
    {
        if (bookshelf != null)
        {
            PlaySound(bigdoor);
        }
        else
        {
            Debug.Log("bigdoor is null");
        }
    }
    public void PlayCabinet()
    {
        if (bookshelf != null)
        {
            PlaySound(cabinet);
        }
        else
        {
            Debug.Log("cabinet is null");
        }
    }
}

    
