using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDamage : MonoBehaviour
{
    [SerializeField]
    ParticleSystem ps;
    [SerializeField]
    BoxCollider boxCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Detection Enemy")
        {
            other.GetComponentInParent<PlayerLifeManager>().SubstractLife();
        }
    }
    void ActivateCollider()
    {
        boxCollider.enabled = true;
    }
    private void OnEnable()
    {    
        Invoke("ActivateCollider", ps.startDelay);
        //Destroy(transform.root, 1);
    }
}
