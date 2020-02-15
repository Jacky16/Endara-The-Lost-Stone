using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baldosa : MonoBehaviour
{
    public string stringCollision;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == stringCollision)
        {
            Destroy(this.gameObject);
        }
    }
    public void CollisonString( string s)
    {
        stringCollision = s;
    }
}
