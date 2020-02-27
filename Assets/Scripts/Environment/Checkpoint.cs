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
            anim.SetTrigger("Checkpoint");
            other.GetComponent<PlayerMovement>().SetRespawn(respawnTransform);
        }
    }
}
