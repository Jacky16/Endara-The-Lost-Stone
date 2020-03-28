using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ExplosionEnemy1 : MonoBehaviour
{
    [SerializeField]float damageExplosion = 0;
    public float radiusExplosion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            float count = 0;
            count = +Time.deltaTime;
            print(count);
            other.SendMessage("RestarLife", 10);
        }      
        return;
    }
    
}
