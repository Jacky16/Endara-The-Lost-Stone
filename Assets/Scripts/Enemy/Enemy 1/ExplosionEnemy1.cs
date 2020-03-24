using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ExplosionEnemy1 : MonoBehaviour
{
    [SerializeField]float damageExplosion = 0;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerLifeManager>().RestarLife(damageExplosion); 
            
            Debug.Log(damageExplosion);
            Destroy(this.gameObject, 2f);
        }
    }
    public void GetDamage(float damage)
    {
        damageExplosion = damage;
    }
    private void OnEnable()
    {
        GetComponent<CinemachineImpulseSource>().GenerateImpulse(Camera.main.transform.forward);

    }
}
