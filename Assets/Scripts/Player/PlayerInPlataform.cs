using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerInPlataform : MonoBehaviour
{
    public bool useGravity;
    Rigidbody rb;
    Vector3 originalPosition;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalPosition = transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().SetMovingPlattform(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
            other.GetComponent<PlayerMovement>().SetMovingPlattform(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }

    void ActiveGravity()
    {
        rb.useGravity = true; 
    }
    public void ReturnOriginal()
    {
        rb.useGravity = false;

        transform.position = originalPosition;  
    }

}

