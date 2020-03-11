using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlataform : MonoBehaviour
{
    float speed;
    [SerializeField]
    float speedMin;
    [SerializeField]
    float speedMax;
    private void Start()
    {
        speed = Random.Range(speedMin, speedMax);
    }
    private void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
