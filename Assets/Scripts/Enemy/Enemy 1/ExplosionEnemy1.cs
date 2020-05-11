using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class ExplosionEnemy1 : MonoBehaviour
{
    bool canDamage = true;
    public CinemachineImpulseSource cinemachineImpulseSource;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if (canDamage)
            {
                other.gameObject.GetComponent<PlayerLifeManager>().SubstractLife();
                cinemachineImpulseSource.GenerateImpulse();
                
            }
            canDamage = false;
        }

    }
    private void OnEnable()
    {
        canDamage = true;
        Destroy(gameObject, 10f);
    }

}
