using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class InteractionSoundPlayer : MonoBehaviour {

    private AudioSource src;

    private void Start()
    {
        src = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        src.clip = clip;
        src.Play();
    }
}
