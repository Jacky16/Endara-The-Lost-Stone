using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerInPlataform : MonoBehaviour
{
    [SerializeField]
    bool doAnimationFall = false;

    Vector3 originalPosition;
    private void Start()
    {
        originalPosition = transform.position;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.transform.SetParent(transform);
            if (doAnimationFall)
            {
                AnimationFall();
            }
            print(other.gameObject.name);
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
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = transform;
        }
    }
    void AnimationFall()
    {
        Sequence secuence = DOTween.Sequence();
        secuence.Append(transform.DOMoveY(transform.position.y - 1f, .3f).SetEase(Ease.OutQuint));
        secuence.Append(transform.DOMoveY(originalPosition.y, 1.5f).SetEase(Ease.OutQuint)); 
    }
}

