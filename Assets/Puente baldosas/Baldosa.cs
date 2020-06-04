using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baldosa : MonoBehaviour
{
    string stringCollision;
    [SerializeField] Rigidbody rb;
    [SerializeField]float speed;
    Vector3 direction;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    public void SetMove(Vector3 v,float f,string s)
    {
        direction = v;
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
            Destroy(this.gameObject,1);
            anim.SetTrigger("Destroy");
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
