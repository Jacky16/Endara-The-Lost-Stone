using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CrushingStone : MonoBehaviour
{
    [SerializeField]
    Transform rockTransform;
    Vector3 _originalPosition;
    private void Start()
    {
        _originalPosition = transform.position;

        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(2);
        sequence.Append(rockTransform.DOShakePosition(0.3f, .5f));
        sequence.Append(rockTransform.DOMoveY(transform.position.y - 4f, .3f));
        sequence.AppendInterval(2);
        sequence.Append(rockTransform.DOMoveY(20, .3f));
        
        sequence.SetLoops(-1);
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.GetComponent<PlayerLifeManager>().SubstractLife();
            other.gameObject.GetComponent<PlayerLifeManager>().SubstractLife();
            rockTransform.GetComponent<BoxCollider>().isTrigger = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            rockTransform.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
