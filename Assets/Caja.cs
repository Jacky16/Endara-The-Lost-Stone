using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
    private void Start()
    {
        //Explosion();
    }
    [SerializeField] GameObject prefabBoxDestroyed;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cola"))
        {
            Explosion();
        }
    }
    void Explosion()
    {
        GameObject go = Instantiate(prefabBoxDestroyed, transform.position, transform.rotation) as GameObject;
        Rigidbody[] rb = go.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody r in rb)
        {
            r.AddExplosionForce(300, transform.position, 30);
        }
        Destroy(this.gameObject);
    }
}
