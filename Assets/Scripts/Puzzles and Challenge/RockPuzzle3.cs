using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RockPuzzle3 : MonoBehaviour
{
    Vector3 _OriginalPosition;
    BoxCollider boxCollider;
    Rigidbody rb;
    bool canSnap = true;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
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
        canSnap = true;
        transform.position = _OriginalPosition;
        yield return new WaitForSeconds(.5f);
        boxCollider.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Snap") && canSnap)
        {
            transform.SetParent(other.transform);
            transform.DOLocalMove(Vector3.zero, 1).OnComplete(() => FreezePosition());
        }
    }

    void FreezePosition()
    {
        canSnap = false;
        rb.isKinematic = true;
    }
}
