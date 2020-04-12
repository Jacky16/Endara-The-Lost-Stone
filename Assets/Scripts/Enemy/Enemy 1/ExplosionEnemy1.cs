using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class ExplosionEnemy1 : MonoBehaviour
{
    [SerializeField]float damageExplosion = 5;
    public float radiusExplosion;
    public CinemachineImpulseSource cinemachineImpulseSource;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Detection Enemy")
        {
            other.gameObject.GetComponentInParent<PlayerLifeManager>().SubstractLife();

        }
    }
    private void OnEnable()
    {
        Destroy(gameObject, 1f);
    }

}
