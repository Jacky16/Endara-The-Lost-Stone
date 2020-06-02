using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisotonDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            other.GetComponent<PlayerLifeManager>().SubstractLife();
            CinemachineImpulseSource cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
            cinemachineImpulseSource.GenerateImpulse();
            Destroy(gameObject, 5);
        }
    }
}
