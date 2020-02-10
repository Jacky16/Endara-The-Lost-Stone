using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_2 : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] LayerMask layerMask;
    public Vector3 direction;
    public Vector3 startPoint;
    public bool chocandoConElCuboDeDelante;
    public bool tieneUnCuboDelante;
    bool laserChocandome;
    GameObject g;
    void Start()
    {
        
    }
    private void Update()
    {
        if (laserChocandome)
        {
            lineRenderer.enabled = true;
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    // Update is called once per frame
    public void Raycast()
    {
        lineRenderer.enabled = true;

        Ray ray = new Ray();
        RaycastHit hit;
        lineRenderer.SetPosition(0, startPoint);
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
        {

            //g = hit.transform.gameObject as GameObject;
            direction.z = hit.distance;
            lineRenderer.SetPosition(1, direction);
            if (hit.transform.tag == "Caja")
            {
                // g = hit.transform.gameObject as GameObject;
                Debug.Log(hit.transform.name);
                chocandoConElCuboDeDelante = true;


            }
            else
            {
                chocandoConElCuboDeDelante = false;



            }
            //if (hit.transform.name == "Cubo3")
            //{
            //    Debug.Log("Tocando el CUBO 3");
            //    //g.GetComponent<Laser>().enabled = true;

            //}


        }

    }
    public void ActivarLineRenderer()
    {
        g.GetComponent<LineRenderer>().enabled = true;

    }
    public void DesactivarLineRender()
    {
        g.GetComponent<LineRenderer>().enabled = false;

    }
}
