using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBounce : MonoBehaviour
{
    public int rayCount = 2;
    public LayerMask layerMask;

    void Update()
    {
        Raycast2(transform.position, transform.forward);

    }
    void Raycast2(Vector3 position, Vector3 direction)
    {
        for (int i = 0; i < rayCount; i++)
        {
            Ray ray = new Ray(position, direction);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10, layerMask))
            {
                Debug.DrawLine(position, hit.point, Color.red);
                position = hit.point;
                direction = hit.normal;
            }
            else
            {
                Debug.DrawRay(transform.position, direction * 10, Color.blue);
                break;
            }
        }
    }
}
