using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

/**
 * Use this script on AudioSource object which has main audioclip attached
 */
public class MusicController : MonoBehaviour
{
    AudioSource musicAudio;

    //Play the music
    bool shouldPlayMusic;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        musicAudio = GetComponent<AudioSource>();
        //Ensure the toggle is set to true for the music to play at start-up
        shouldPlayMusic = true;
        musicAudio.Play();
    }

    public void toggleBGMusic()
    {
        shouldPlayMusic = !shouldPlayMusic;

        if (shouldPlayMusic)
        {
            //Play the audio you attach to the AudioSource component
            musicAudio.Play();
        } else
        {
            //Stop the audio
            musicAudio.Pause();
        }
    }

}
