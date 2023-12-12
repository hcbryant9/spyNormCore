using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource playerAudioSource;
    public AudioClip headphones;
    public AudioClip briefcase;
    void Start()
    {
        // Get the AudioSource component attached to the player
        
            playerAudioSource = GetComponent<AudioSource>();
        
            //Debug.Log("playerAudio Source is null in audio controller script");
        
        

        // For example, play an initial sound when the scene starts
        //PlaySound(someAudioClip); // Replace someAudioClip with the AudioClip you want to play
    }

    // Function to play a sound through the player's AudioSource
    public void PlaySound(AudioClip clip)
    {
        if (clip != null && playerAudioSource != null)
        {
            playerAudioSource.clip = clip;
            playerAudioSource.Play();
        } else
        {
            if (clip == null)
            {
                Debug.Log("the clip is null");
            } else
            {
                Debug.Log("the source is null");
            }
        }
    }

    // You can add more functions here for different sound effects or actions
    // For instance:
    public void PlayHeadphones()
    {
        if(headphones!= null)
        {
            PlaySound(headphones);
        } else
        {
            Debug.Log("headphones is null");
        }
    }
    public void PlayBriefcase()
    {
        if (briefcase != null)
        {
            PlaySound(briefcase);
        } else
        {
            Debug.Log("briefcase is null");
        }
    }
}
