using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RockEnemy2 : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    public GameObject impactPrefab;
    [SerializeField] GameObject impactPlayer;
    public List<GameObject> trails;
    Animator anim;
    Vector3 directionToPlayer;
    bool canGo;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if (canGo)
        {
            rb.velocity = directionToPlayer * (speed * Time.deltaTime);
            transform.DOLocalRotate(new Vector3(100, 0, 0), 3, RotateMode.LocalAxisAdd).SetLoops(-1);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        speed = 0;
           
        if(collision.collider.gameObject.name != gameObject.name && collision.collider.gameObject.tag != "Player")
        {
            ContactPoint contactPoint = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contactPoint.normal);
            Vector3 pos = contactPoint.point;

            GameObject impact = Instantiate(impactPrefab, pos, rot) as GameObject;
            print(collision.gameObject.name);
            Destroy(impact, 5);
        }
        if(collision.collider.gameObject.tag == "Player")
        {
            GameObject impact = Instantiate(impactPrefab, collision.transform.position, Quaternion.identity);
            Destroy(impact, 5);
        }

        if (trails.Count > 0)
        {
            foreach (GameObject g in trails)
            {
                g.transform.SetParent(null);
                ParticleSystem p = g.GetComponent<ParticleSystem>();
                if (p != null)
                {
                    p.Stop();
                    Destroy(p.gameObject, p.main.duration + p.startLifetime);
                }
            }
        }
        Destroy(gameObject);

        

    }
    public void ShootRock(Vector3 dir, bool b)
    {
        directionToPlayer = dir;
        canGo = b;
    }
   
    private void OnEnable()
    {
        anim.SetTrigger("Spawn");
    }
}
