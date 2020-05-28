using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(Rigidbody))]

public class ObjetoPickeable : MonoBehaviour
{
    public bool isPickeable;
    public bool isRoteable;
    [SerializeField]
    bool emitParticleSmoke;

    [SerializeField]
    ParticleSystem particleSmoke;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerInteraction")
        {
            other.GetComponentInParent<PickUpObjects>().objectToPickup = this.gameObject;
            other.GetComponentInParent<PickUpObjects>().SetCanCatch(isPickeable);
            other.GetComponentInParent<PickUpObjects>().SetCanRotate(isRoteable);

        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerInteraction")
        {
            other.GetComponentInParent<PickUpObjects>().objectToPickup = null;
            other.GetComponentInParent<PickUpObjects>().SetCanCatch(false);
            other.GetComponentInParent<PickUpObjects>().SetCanRotate(!isRoteable && false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (emitParticleSmoke)
        {
            particleSmoke.Play();
        }
        
    }


}