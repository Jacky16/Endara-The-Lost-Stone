using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(EventTrigger))]
public class SoundButtons : MonoBehaviour
{
    [SerializeField]
    AudioClip audioClipMouseOver;
    [SerializeField]
    AudioClip audioClipMouseClick;

    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.volume = 0.2f;
    }

    public void SoundMouseOver() //Raton por encima
    {
        
            audioSource.PlayOneShot(audioClipMouseOver);
        
    }
    public void SoundMouseClick() //He clickado
    {
        
        audioSource.PlayOneShot(audioClipMouseClick);
        
    }
}
