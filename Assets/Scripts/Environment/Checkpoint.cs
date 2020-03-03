using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] Transform respawnTransform;
    Animator anim;
    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            anim.SetTrigger("Checkpoint");
            player.SetRespawn(respawnTransform);
            SaveData(player);
        }
    }
    public void SaveData(PlayerMovement player)
    {
        //SaveSystem.SavePlayer(player);
    }
}
