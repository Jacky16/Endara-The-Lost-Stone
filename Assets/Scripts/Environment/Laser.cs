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
    [Header("Bools para combrobar si recibe el Raycast")]

    [SerializeField] bool activarRaycast;
    [SerializeField] bool reciboRaycast;
    GameObject cuboHijoGameObject;
    GameObject gameObjectSolution;

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
                if (hit.transform.gameObject.tag == "Solution")
                {
                    gameObjectSolution = hit.transform.gameObject;
                    gameObjectSolution.GetComponent<Animator>().SetBool("Iluminate",true);

                }
                else 
                {
                    if(gameObjectSolution!= null)
                    gameObjectSolution.GetComponent<Animator>().SetBool("Iluminate", false);
                    gameObjectSolution = null;
                }

                if (hit.transform.tag == "Cubo") // Choca con un cubo hijo
                {

                    //Obtener el cubo que tiene delante
                    cuboHijoGameObject = hit.transform.gameObject as GameObject;

                    //Como recibe el Raycast, ponemos la variable a true
                    cuboHijoGameObject.GetComponent<Laser>().reciboRaycast = true;

                }
               
                else if (hit.transform.tag != "Cubo") 
                {
                    //Desactiva el Line Renderer y el raycast de todos los cubos cuando no colsiona el rayo excepto el ultimo
                   if(cuboHijoGameObject != null)
                    cuboHijoGameObject.GetComponent<Laser>().reciboRaycast = false;
                    cuboHijoGameObject.GetComponent<Laser>().activarRaycast = false;
                    cuboHijoGameObject.GetComponent<Laser>().DesactivarLineRender();
                    

                  
                    
                    if (!cuboPadre)
                    {
                        DesactivarLineRender();
                    }
                    //Manera para desactivar el LineRenderer del ultimo cubo
                    GameObject[] cubos = GameObject.FindGameObjectsWithTag("Cubo");
                    foreach (GameObject g in cubos)
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
