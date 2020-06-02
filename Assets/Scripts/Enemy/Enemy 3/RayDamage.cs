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
            if(other.GetComponentInParent<PlayerLifeManager>().AttempsPlayer() <= 0)
            {
                Destroy(transform.root.gameObject);
            }
            other.GetComponentInParent<PlayerLifeManager>().SubstractLife();

        }
    }
    void ActivateCollider()
    {
        StartCoroutine(CoroutineBoxCollider());
    }
    private void OnEnable()
    {    
        Invoke("ActivateCollider", ps.startDelay);
        //Destroy(transform.root, 1);
    }
    IEnumerator CoroutineBoxCollider()
    {
        boxCollider.enabled = true;
        yield return new WaitForSeconds(0.2f);
        boxCollider.enabled = false;
    }
}
