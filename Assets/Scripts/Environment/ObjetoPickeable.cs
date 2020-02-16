using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjetoPickeable : MonoBehaviour
{
    public bool isPickeable = true;
    public bool isRoteable = false;
    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerInteraction")
        {
            other.GetComponentInParent<PickUpObjects>().objectToPickup = this.gameObject;
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerInteraction")
        {
            other.GetComponentInParent<PickUpObjects>().objectToPickup = null;

        }
    }
    
}