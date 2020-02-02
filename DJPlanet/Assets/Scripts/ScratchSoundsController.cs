using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

/**
 * Use this script on AudioSource object without main clip attached
 * Set scratchSounds list to contain multiple AudioClip objects to randomly
 * play when playScratchSound method is called
 * Wire a trigger to call playScratchSound when you need
 */
public class ScratchSoundsController : MonoBehaviour
{
    // list of scratch sounds to pick from
    public List<AudioClip> scratchSounds = new List<AudioClip>();

    // don't play sound again for this long
    public float audioDebounce = 0.3f;

    AudioSource scratchAudio;

    static Random rnd = new Random();

    bool canPlay = true;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        scratchAudio = GetComponent<AudioSource>();
    }

    // play a random scratch sound
    public void playScratchSound()
    {
        if (canPlay)
        {
            canPlay = false;

            scratchAudio.PlayOneShot((AudioClip)scratchSounds[Random.Range(0, scratchSounds.Count)]);
            StartCoroutine(Reset());
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(audioDebounce);
        canPlay = true;
    }
}
