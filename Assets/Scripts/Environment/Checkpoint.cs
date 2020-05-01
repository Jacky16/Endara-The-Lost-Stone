using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    Transform respawnTransform;
    Animator anim;
    AudioSource _audioSource;
    [SerializeField]
    //ParticleSystem[] _particleSystems;
    bool playerHaveCheckpoint;
    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
        _audioSource = GetComponentInParent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerHaveCheckpoint)
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            anim.SetTrigger("Checkpoint");
            player.SetRespawn(respawnTransform);
            SaveData(player);
            _audioSource.Play();
            //Playparticles();
            playerHaveCheckpoint = true;
        }

    }
    public void SaveData(PlayerMovement player)
    {
        //SaveSystem.SavePlayer(player);
    }
    //void Playparticles()
    //{
    //    foreach(ParticleSystem ps in _particleSystems)
    //    {
    //        ps.Play();
    //    }
    //}
}
