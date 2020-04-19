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
        sequence.Append(transform.DOShakePosition(0.3f, .5f));
        sequence.Append(transform.DOMoveY(transform.position.y - 6.3f, .5f));
        sequence.AppendInterval(2);
        sequence.Append(transform.DOMoveY(_originalPosition.y, .5f));
        
        sequence.SetLoops(-1);
    }
}
