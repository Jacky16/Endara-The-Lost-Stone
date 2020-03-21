using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimationOnEnable : MonoBehaviour
{
    RectTransform myRectTransform;
    private void OnEnable()
    {
        myRectTransform = GetComponent<RectTransform>();
    }
}
