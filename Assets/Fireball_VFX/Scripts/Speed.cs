using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    public GameObject impactPrefab;
    public List<GameObject> trails;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.forward * (speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        speed = 0;
        ContactPoint contactPoint = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contactPoint.normal);
        Vector3 pos = contactPoint.point;
        if(impactPrefab != null) {
            GameObject impact = Instantiate(impactPrefab, pos, rot) as GameObject;
            Destroy(impact, 5);
        }
        if (trails.Count > 0)
        {
            foreach(GameObject g in trails)
            {
                g.transform.SetParent(null);
                ParticleSystem p = g.GetComponent<ParticleSystem>();
                if(p!= null)
                {
                    p.Stop();
                    Destroy(p.gameObject, p.main.duration + p.startLifetime);
                }
            }
        }
        Destroy(gameObject);
    }
}
