using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLanding : MonoBehaviour
{
    PlayerSoundMovement playerSoundMovement;
    private void Awake()
    {
        playerSoundMovement = GetComponentInParent<PlayerSoundMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 13)
        {
            playerSoundMovement.PlaySoundLanding();
        }
    }
}
