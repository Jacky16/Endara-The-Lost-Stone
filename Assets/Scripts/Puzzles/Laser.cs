using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    LineRenderer _lineRenderer;
    [SerializeField] 
    LayerMask _layerMask;
    public Vector3 direction;
    public Vector3 startPoint;
    [Header("Tipos de cubo")]
    public bool cuboPadre;
    public bool cuboHijo;
    [Header("Bools para combrobar si recibe el Raycast")]

    [SerializeField] 
    bool _activarRaycast;
    [SerializeField] 
    bool _reciboRaycast;
    GameObject _cuboHijoGameObject;
    GameObject _gameObjectSolution;
    [Header("Materiales")]
    [SerializeField]
    Material _materialWithEmision;
    [SerializeField]
    Material _materialWithoutEmision;
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        startPoint = new Vector3(0.01f, .4f, 0);
        direction = new Vector3(.1f, .4f, 0);

        if (cuboPadre)
        {
            ActivarLineRenderer();
            GetComponent<MeshRenderer>().material = _materialWithEmision;

        }
        else if (cuboHijo)
        {
            DesactivarLineRender();
            GetComponent<MeshRenderer>().material = _materialWithoutEmision;

        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Raycast();
        if (cuboPadre)
        {
            ActivarLineRenderer();

            _activarRaycast = true;
        }

        if (cuboHijo && _reciboRaycast) // Recibe Raycast el CUBO HIJO
        {
            _activarRaycast = true;

            ActivarLineRenderer();
        }
        else if (cuboHijo && !_reciboRaycast) //Deja de recibir el Raycast el CUBO HIJO
        {
            DesactivarLineRender();
            _activarRaycast = false;

        }
        else if (!_reciboRaycast && !cuboPadre)
        {
            DesactivarLineRender();
            _activarRaycast = false;
        }
        else if (_cuboHijoGameObject == null && !cuboPadre)
        {
            DesactivarLineRender();
        }

    }
    public void Raycast()
    {
        if (_activarRaycast)
        {
            Ray ray = new Ray();
            RaycastHit hit;
            _lineRenderer.SetPosition(0, startPoint);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, _layerMask))
            {
                //Calcular la distancia entre el punto mas lejano que esta tocando el Raycast
                direction.z = hit.distance;
                //Asignar la posicion del Raycast al Linerenderer
                _lineRenderer.SetPosition(1, direction);
                if (hit.transform.gameObject.tag == "Solution")
                {
                    _gameObjectSolution = hit.transform.gameObject;
                    _gameObjectSolution.GetComponent<Animator>().SetBool("Iluminate", true);
                    if (!_gameObjectSolution.GetComponent<GemaPuzzle>().IsSolution())
                    {

                        _gameObjectSolution.GetComponent<GemaPuzzle>().Solution(true);

                    }


                }
                else
                {
                    if (_gameObjectSolution != null)
                        _gameObjectSolution.GetComponent<Animator>().SetBool("Iluminate", false);
                    _gameObjectSolution = null;
                }

                if (hit.transform.tag == "Cubo") // Choca con un cubo hijo
                {
                    print(hit.transform.gameObject.name);

                    //Obtener el cubo que tiene delante
                    _cuboHijoGameObject = hit.transform.gameObject as GameObject;

                    //Como recibe el Raycast, ponemos la variable a true
                    _cuboHijoGameObject.GetComponent<Laser>()._reciboRaycast = true;
                    _cuboHijoGameObject.GetComponent<MeshRenderer>().material = _materialWithEmision;

                }

                else if (hit.transform.tag != "Cubo")
                {
                    //Desactiva el Line Renderer y el raycast de todos los cubos cuando no colsiona el rayo excepto el ultimo
                    if (_cuboHijoGameObject != null)
                        _cuboHijoGameObject.GetComponent<Laser>()._reciboRaycast = false;
                    _cuboHijoGameObject.GetComponent<Laser>()._activarRaycast = false;
                    _cuboHijoGameObject.GetComponent<Laser>().DesactivarLineRender();
                    _cuboHijoGameObject.GetComponent<MeshRenderer>().material = _materialWithoutEmision;




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
                            g.GetComponent<Laser>()._reciboRaycast = false;
                            g.GetComponent<Laser>()._activarRaycast = false;
                            g.GetComponent<Laser>().DesactivarLineRender();
                            g.GetComponent<MeshRenderer>().material = _materialWithoutEmision;

                        }
                    }
                    _cuboHijoGameObject = null;
                }


            }
        }
    }
    public void ActivarLineRenderer()
    {
        _lineRenderer.enabled = true;
    }
    public void DesactivarLineRender()
    {
        _lineRenderer.enabled = false;
    }

}
