using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoPickeable : MonoBehaviour
{
    public bool isPickeable = true;
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