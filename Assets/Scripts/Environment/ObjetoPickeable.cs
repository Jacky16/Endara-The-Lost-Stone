using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(Rigidbody))]

public class ObjetoPickeable : MonoBehaviour
{
    public bool isPickeable = true;
    public bool isRoteable = false;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerInteraction")
        {
            other.GetComponentInParent<PickUpObjects>().objectToPickup = this.gameObject;
            other.GetComponentInParent<PickUpObjects>().SetCanCatch(isPickeable);
            other.GetComponentInParent<PickUpObjects>().SetCanRotate(isRoteable && true);

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
    
    
}