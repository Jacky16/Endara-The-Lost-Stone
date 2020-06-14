using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AnimationRockPedestal : MonoBehaviour
{
    [SerializeField] float speed;
    public enum Direction { Left,Right}
    public Direction direction;
    Vector3 originalPosition;
    private void Start()
    {
        originalPosition = transform.position;
        switch (direction) 
        {
            case Direction.Left:
                transform.DOLocalRotate(new Vector3(0, 0, -360), speed, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
                break; 
            case Direction.Right:
                transform.DOLocalRotate(new Vector3(0, 0, 360), speed, RotateMode.LocalAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
                break;
        }

    }
}
