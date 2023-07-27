using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public static GlobalAudioPlayer AudioInstance;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (AudioInstance != null && AudioInstance != this)
        {
            Destroy(this);
        }
        else
        {
            AudioInstance = this;
        }
    }

    public void PlayClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
