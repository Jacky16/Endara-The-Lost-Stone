using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] LayerMask layerMask;
    public Vector3 direction;
    public Vector3 startPoint;
    [Header("Tipos de cubo")]
    public bool cuboPadre;
    public bool cuboHijo;
    public bool cuboFinal;
    [SerializeField]bool activarRaycast;
    [SerializeField] bool reciboRaycast;
    GameObject cuboHijoGameObject;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        startPoint = new Vector3(0.01f, 0.01f,0);
        direction = new Vector3(.1f, .1f,0);
        //this.rendererEnabled = true;
        if (cuboPadre)
        {
            ActivarLineRenderer();

        }
        else if (cuboHijo)
        {
            DesactivarLineRender();
        }
        else if (cuboFinal)
        {
            DesactivarLineRender();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Raycast();
        if (cuboPadre)
        {
            ActivarLineRenderer();
            
            activarRaycast = true;
        }
        
        if(cuboHijo && reciboRaycast) // Recibe Raycast el CUBO HIJO
        {
            activarRaycast = true;

            ActivarLineRenderer();
        }else if(cuboHijo && !reciboRaycast ) //Deja de recibir el Raycast el CUBO HIJO
        {
            DesactivarLineRender();
            activarRaycast = false;

        //}else if (cuboFinal && reciboRaycast) // Recibe Raycast el CUBO FINAL
        //{
        //    activarRaycast = true;
        //    ActivarLineRenderer();
        //}
        //else if (cuboFinal && !reciboRaycast) //Deja de recibir el Raycast el CUBO FINAL
        //{
        //    activarRaycast = false;

        //    DesactivarLineRender();
        }else if (!reciboRaycast && !cuboPadre)
        {
            DesactivarLineRender();
            activarRaycast = false;
        }else if (cuboHijoGameObject == null && !cuboPadre)
        {
            DesactivarLineRender();
        }
   
    }
    public void Raycast()
    {
        if (activarRaycast)
        {
            Ray ray = new Ray();
            RaycastHit hit;
            lineRenderer.SetPosition(0, startPoint);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                //Calcular la distancia entre el punto mas lejano que esta tocando el Raycast
                direction.z = hit.distance;
                //Asignar la posicion del Raycast al Linerenderer
                lineRenderer.SetPosition(1, direction);


                if (hit.transform.name == "Cubo") // Choca con un cubo hijo
                {

                    //Obtener el cubo que tiene delante
                    cuboHijoGameObject = hit.transform.gameObject as GameObject;

                    //Como recibe el Raycast, ponemos la variable a true
                    cuboHijoGameObject.GetComponent<Laser>().reciboRaycast = true;




                }
               
                else if (hit.transform.name != "Cubo") 
                {

                    cuboHijoGameObject.GetComponent<Laser>().reciboRaycast = false;
                    cuboHijoGameObject.GetComponent<Laser>().activarRaycast = false;
                    cuboHijoGameObject.GetComponent<Laser>().DesactivarLineRender();
                    GameObject [] cubos = GameObject.FindGameObjectsWithTag("Cubo");
                    if (!cuboPadre)
                    {
                        DesactivarLineRender();
                    }
                    foreach(GameObject g in cubos)
                    {
                        if (!g.GetComponent<Laser>().cuboPadre)
                        {
                            g.GetComponent<Laser>().reciboRaycast = false;
                            g.GetComponent<Laser>().activarRaycast = false;
                            g.GetComponent<Laser>().DesactivarLineRender();
                        }
                    }
                    cuboHijoGameObject = null;


                }
                //else if(hit.transform.name == "Cubo_Final")
                //{
                //    //if (cuboDeDelante.GetComponent<Laser>().cuboHijo)
                //    //{
                //    //    cuboDeDelante.GetComponent<Laser>().reciboRaycast = false;
                //    //    cuboDeDelante.GetComponent<Laser>().activarRaycast = false;

                //    //    cuboDeDelante.GetComponent<Laser>().DesactivarLineRender();
                //    //    //cuboDeDelante = null;

                //    //}
                //}


            }
        }
  
    }
    public void ActivarLineRenderer()
    {
        lineRenderer.enabled = true;

    }
    public void DesactivarLineRender()
    {
        lineRenderer.enabled = false;

    }
    
}
