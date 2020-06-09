using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundMovement : MonoBehaviour
{
    AudioSource audioSource;
    public enum typeOfGround { Tierra,Hierba,Piedra};
    public typeOfGround typeOfGroundState;

    [Header("Audios Walk")]
    [SerializeField]
    AudioClip[] audiosWalk_Tierra;
    [SerializeField]
    AudioClip[] audiosWalk_Hierba;
    [SerializeField]
    AudioClip[] audiosWalk_Piedra;

    [Header("Audios Run")]
    [SerializeField]
    AudioClip[] audiosRun_Tierra;
    [SerializeField]
    AudioClip[] audiosRun_Hierba;
    [SerializeField]
    AudioClip[] audiosRun_Piedra;
    
    [Header("Audios Landing")]
    [SerializeField]
    AudioClip[] audiosLanding_Tierra;
    [SerializeField]
    AudioClip[] audiosLanding_Hierba;
    [SerializeField]
    AudioClip[] audiosLanding_Piedra;

    [Header("Audios Attack")]
    [SerializeField]
    AudioClip audioAttack;

    [Header("Audios Jump")]
    [SerializeField]
    AudioClip[] audiosJump;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundWalk() //Sonidos de caminar
    {
        if (!audioSource.isPlaying)
        {
            switch (typeOfGroundState)
            {
                case typeOfGround.Tierra:
                    audioSource.PlayOneShot(audiosWalk_Tierra[Random.Range(0, audiosWalk_Tierra.Length)]);
                    break;
                case typeOfGround.Hierba:
                    audioSource.PlayOneShot(audiosWalk_Hierba[Random.Range(0, audiosWalk_Hierba.Length)]);
                    break;
                case typeOfGround.Piedra:
                    audioSource.PlayOneShot(audiosWalk_Piedra[Random.Range(0, audiosWalk_Piedra.Length)]);
                    break;
            }
        }
    }
    public void PlaySoundRun() //Sonidos de correr
    {
        if (!audioSource.isPlaying)
        {
            switch (typeOfGroundState)
            {
                case typeOfGround.Tierra:
                    audioSource.PlayOneShot(audiosWalk_Tierra[Random.Range(0, audiosWalk_Tierra.Length)]);
                    break;
                case typeOfGround.Hierba:
                    audioSource.PlayOneShot(audiosRun_Hierba[Random.Range(0, audiosRun_Hierba.Length)]);
                    break;
                case typeOfGround.Piedra:
                    audioSource.PlayOneShot(audiosRun_Piedra[Random.Range(0, audiosRun_Piedra.Length)]);
                    break;
            }
        }
    }
    public void PlaySoundLanding() //Sonidos de caer al suelo (Landing)
    {
        if (!audioSource.isPlaying)
        {
            switch (typeOfGroundState)
            {
                case typeOfGround.Tierra:
                    audioSource.PlayOneShot(audiosLanding_Tierra[Random.Range(0, audiosLanding_Tierra.Length)]);
                    break;
                case typeOfGround.Hierba:
                    audioSource.PlayOneShot(audiosLanding_Hierba[Random.Range(0, audiosLanding_Hierba.Length)]);
                    break;
                case typeOfGround.Piedra:
                    audioSource.PlayOneShot(audiosLanding_Piedra[Random.Range(0, audiosLanding_Piedra.Length)]);
                    break;
            }
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
