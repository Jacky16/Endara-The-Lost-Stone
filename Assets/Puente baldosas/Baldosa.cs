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
   
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Baldosa")
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}
   
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
