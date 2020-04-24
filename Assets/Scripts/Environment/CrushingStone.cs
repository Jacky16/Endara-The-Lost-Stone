using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CrushingStone : MonoBehaviour
{
    Vector3 _originalPosition;
    private void Start()
    {
        _originalPosition = transform.position;

        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(2);
        sequence.Append(transform.DOShakePosition(0.3f, .5f));
        sequence.Append(transform.DOMoveY(transform.position.y - 6f, .3f));
        sequence.AppendInterval(2);
        sequence.Append(transform.DOMoveY(_originalPosition.y, .3f));
        
        sequence.SetLoops(-1);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<PlayerLifeManager>().SubstractLife();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<PlayerLifeManager>().SubstractLife();
        }
    }
}
