using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDragRock : MonoBehaviour
{
    [SerializeField]
    AudioClip[] _AudioClips;

    AudioSource audioSource;
    Rigidbody rb;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > 0)
        {
            PlayAudio();
        }else if(rb.velocity.magnitude <= 0)
        {
            StopAudio();
        }
    }
    public void PlayAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.volume = 1;
            audioSource.PlayOneShot(AudiosDragRock());
        }
           
    }
    public void StopAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.DOFade(0, 1).OnComplete(() => audioSource.Stop());
        }
    }
    private AudioClip AudiosDragRock()
    {
        return _AudioClips[Random.Range(0, _AudioClips.Length)];
    }
    
}
