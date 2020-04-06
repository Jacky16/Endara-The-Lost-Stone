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
            
            //Invoke("ActiveGravity", .5f);
            //if (!useGravity)
            //{
            //    Sequence forceSequence = DOTween.Sequence();
            //    forceSequence.Append(transform.DOLocalMoveY(transform.position.y -0.1f, .3f)).SetEase(Ease.InBack).Append(transform.DOLocalMoveY(transform.position.y + 0.1f, .3f)).SetEase(Ease.OutBack);
            //}
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

