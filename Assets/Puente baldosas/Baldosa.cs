using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baldosa : MonoBehaviour
{
    string stringCollision;
    [SerializeField] Rigidbody rb;
    [SerializeField]float speed;
    Vector3 position;
  
    private void Update()
    {
        transform.Translate(position * speed * Time.deltaTime);

    }
     
    public void SetMove(Vector3 v,float f,string s)
    {
        position = v;
        speed = f;
        stringCollision = s;

    }
     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
        if (other.gameObject.name == stringCollision)
        {
            transform.DetachChildren();
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }



}
