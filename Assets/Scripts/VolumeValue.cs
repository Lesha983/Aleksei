using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValue : MonoBehaviour
{
    private AudioSource _audioSrc;

    private void Start()
    {
        _audioSrc = GetComponent<AudioSource>();
    }

    public void SetVolume(float volume)
    {
        _audioSrc.volume = volume;
    }
}
