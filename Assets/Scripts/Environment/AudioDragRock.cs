using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioDragRock : MonoBehaviour
{
    [SerializeField]
    AudioClip[] _AudioClips;

    AudioSource audioSource;
    Rigidbody rb;

    bool playerIsPushing;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
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
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Animator>().SetBool("isPushing", true);
            playerIsPushing = true;
            if (rb.velocity.magnitude > 0 && playerIsPushing)
            {
                PlayAudio();
            }
            else
            {
                StopAudio();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Animator>().SetBool("isPushing", false);
            playerIsPushing = false;
            StopAudio();      
        }
    }
}
