using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollection : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonSound;
    public AudioClip itemGet;

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSound);
    }
    public void PlayItemGet()
    {
        audioSource.PlayOneShot(itemGet);
    }
}
