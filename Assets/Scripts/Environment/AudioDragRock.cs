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
    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > 0 && playerIsPushing)
        {
            PlayAudio();
        }else if(rb.velocity.magnitude <= 0 && !playerIsPushing)
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Animator>().SetBool("isPushing", false);
            playerIsPushing = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Animator>().SetBool("isPushing", false);
            playerIsPushing = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Animator>().SetBool("isPushing", false);

        }
    }
   

}
