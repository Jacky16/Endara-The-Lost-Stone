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
    [SerializeField]
    ParticleSystem particleSystemSmoke;

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
            audioSource.volume = 0.5f;
            audioSource.PlayOneShot(AudiosDragRock());
        } 
    }
    public void StopAudio()
    {    
        audioSource.DOFade(0, 1).OnComplete(() => audioSource.Stop());       
    }
    private AudioClip AudiosDragRock()
    {
        return _AudioClips[Random.Range(0, _AudioClips.Length)];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Interaction Zone")
        {
            playerIsPushing = true;
            other.GetComponentInParent<Animator>().SetBool("isPushing", playerIsPushing);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        float magnitudeRock = Mathf.Clamp01(rb.velocity.magnitude);
        if (magnitudeRock > 0 && playerIsPushing)
        {
            PlayAudio();
        }
        else if (magnitudeRock <= 0)
        {
            StopAudio();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Interaction Zone")
        {
            playerIsPushing = false;
            other.GetComponentInParent<Animator>().SetBool("isPushing", playerIsPushing);
        }
    }
}