using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundMovement : MonoBehaviour
{
    AudioSource audioSource;

    [Header("Audios Walk")]
    [SerializeField]
    AudioClip[] audiosWalk;

    [Header("Audios Walk")]
    [SerializeField]
    AudioClip[] audiosRun;

    [Header("Audios Jump")]
    [SerializeField]
    AudioClip[] audiosJump;

    [Header("Audios Attack")]
    [SerializeField]
    AudioClip audioAttack;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundWalk() //Sonidos de caminar
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audiosWalk[Random.Range(0, audiosWalk.Length)]);
        }
    }
    public void PlaySoundRun() //Sonidos de correr
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audiosRun[Random.Range(0, audiosRun.Length)]);

        }
    }
    public void PlaySoundJump() //Sonidos de salto
    {       
            audioSource.PlayOneShot(audiosJump[Random.Range(0, audiosJump.Length)]);
    }

    public void PlaySoundAttack()
    {
        audioSource.PlayOneShot(audioAttack);
    }




}
