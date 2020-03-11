using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInPlataform : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }

}

