using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RockPuzzle3 : MonoBehaviour
{
    Vector3 _OriginalPosition;
    BoxCollider boxCollider;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }
    private void Start()
    {
        _OriginalPosition = transform.position;
    }
    public void ResetPosition()
    {
        StartCoroutine(ResetPositionCoroutine());
    }
    IEnumerator ResetPositionCoroutine()
    {
        boxCollider.enabled = false;
        transform.position = _OriginalPosition;
        yield return new WaitForSeconds(.5f);
        boxCollider.enabled = true;

    }
}
