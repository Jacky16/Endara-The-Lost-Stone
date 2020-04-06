using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlataform : MonoBehaviour
{
    [SerializeField]
    float speed;
  
    private void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
