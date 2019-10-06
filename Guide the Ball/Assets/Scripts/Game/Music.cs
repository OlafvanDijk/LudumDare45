using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    private AudioClip clip;

    public void PlayMusic(bool play)
    {
        if (play)
        {
            audio.clip = clip;
            audio.Play();
        }
        else
        {
            audio.Stop();
        }
    }
}
