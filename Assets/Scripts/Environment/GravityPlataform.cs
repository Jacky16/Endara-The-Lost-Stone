using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlataform : MonoBehaviour
{
    [SerializeField]
    float speed;
    bool _isGravity;
    Vector3 originalPosition;
    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (_isGravity)
        {
            this.transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }
    }
    public void SetGravity(bool b)
    {
        _isGravity = b;
    }
    public void SetOriginalPosition()
    {
        transform.position = originalPosition;
    }
}
