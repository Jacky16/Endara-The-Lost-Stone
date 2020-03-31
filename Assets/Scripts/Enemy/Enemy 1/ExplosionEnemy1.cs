using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ExplosionEnemy1 : MonoBehaviour
{
    [SerializeField]float damageExplosion = 5;
    public float radiusExplosion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.SendMessage("RestarLife", damageExplosion / 2);


        }
        return;
    }
    
}
