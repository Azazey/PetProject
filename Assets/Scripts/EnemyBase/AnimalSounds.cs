using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _idleAudio;
    [SerializeField] private AudioSource _angryAudio;
    
    private void PlayIdleSound()
    {
        _idleAudio.Play();    
    }

    private void PlayAngryAuido()
    {
        _angryAudio.Play();
    }
}
