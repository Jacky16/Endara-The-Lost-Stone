using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Portal : MonoBehaviour
{
    [SerializeField]
    PlayableDirector playableDirector;
   
    AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        playableDirector.Play();
    }
    public void PlayAudio()
    {
        audioSource.Play();
    }
}
