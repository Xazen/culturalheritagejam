using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollection : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip buttonSound;

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSound);
    }
}
