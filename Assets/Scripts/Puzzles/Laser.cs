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
    [SerializeField]List<GameObject> _listGameObjectsGemaPuzzle = new List<GameObject>();
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
        //RaycastAll();
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
    const float lineLenght = 30;
    void RaycastAll()
    {
        if (_activarRaycast)
        {
            Ray ray = new Ray();
            RaycastHit [] hits;
            hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward),lineLenght, _layerMask);
            print(hits.Length);
            //Asigno la longitud del LineRenderer
            direction.z = lineLenght;
            float lenghtUntilSolid = lineLenght;
            for (int i = 0; i < hits.Length; i++)
            {
                if (!hits[i].collider.CompareTag("Solution"))
                {
                    if(lenghtUntilSolid > hits[i].distance)
                    {
                        lenghtUntilSolid = hits[i].distance;
                    }
                }
            }

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.gameObject != gameObject)
                {


                    if (hits[i].collider.CompareTag("Solution"))
                    {
                        if (lenghtUntilSolid > hits[i].distance)
                        {
                            GemaPuzzle gemaPuzzle = hits[i].collider.gameObject.GetComponent<GemaPuzzle>();
                            gemaPuzzle.Solution(true);
                        }
                    }
                    else
                    {
                        if (hits[i].transform.tag == "Cubo") // Choca con un cubo hijo
                        {
                            if (lenghtUntilSolid > hits[i].distance - 0.01f)
                            {
                                //Obtener el cubo que tiene delante
                                _cuboHijoGameObject = hits[i].transform.gameObject as GameObject;

                                //Como recibe el Raycast, ponemos la variable a true
                                _cuboHijoGameObject.GetComponent<Laser>()._reciboRaycast = true;
                                _cuboHijoGameObject.GetComponent<MeshRenderer>().material = _materialWithEmision;

                            }
                            else
                            {
                                _cuboHijoGameObject.GetComponent<Laser>()._reciboRaycast = false;
                                _cuboHijoGameObject.GetComponent<Laser>()._activarRaycast = false;
                                _cuboHijoGameObject.GetComponent<Laser>().DesactivarLineRender();
                                _cuboHijoGameObject.GetComponent<MeshRenderer>().material = _materialWithoutEmision;
                            }
                        }


                    }
                }
            }
            for (int i = 0; i < hits.Length; i++)
            {

            }

                

            _lineRenderer.SetPosition(0, startPoint);
           
        }
    }
    public void Raycast()
    {
        if (_activarRaycast)
        {
            Ray ray = new Ray();
            RaycastHit hits;
            _lineRenderer.SetPosition(0, startPoint);
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hits, Mathf.Infinity, _layerMask))
            {
                //Calcular la distancia entre el punto mas lejano que esta tocando el Raycast
                direction.z = hits.distance;
                //Asignar la posicion del Raycast al Linerenderer
                _lineRenderer.SetPosition(1, direction);

                if (hits.transform.gameObject.tag == "Solution")
                {
                    _listGameObjectsGemaPuzzle.Add(hits.transform.gameObject);

                    foreach (GameObject g in _listGameObjectsGemaPuzzle) //Para activar todas las gemas
                    {
                        g.GetComponent<GemaPuzzle>().Solution(true);
                        g.GetComponent<Animator>().SetBool("Iluminate", true);
                    }


                    //print(_listGameObjectGemaSolution.Count);
                    //direction.z = hit.distance + Vector3.Distance(transform.position, _listGameObjectGemaSolution[_listGameObjectGemaSolution.Count - 1].transform.position);
                }
                else
                {
                    if (hits.transform.gameObject.tag != "Solution")
                    {
                        if (_listGameObjectsGemaPuzzle.Count > 1)
                        {
                            foreach (GameObject g in _listGameObjectsGemaPuzzle) //Para activar todas las gemas
                            {
                                g.GetComponent<GemaPuzzle>().Solution(false);
                                g.GetComponent<Animator>().SetBool("Iluminate", false);
                            }
                            _listGameObjectsGemaPuzzle.Clear();
                        }
                    }
                }


                if (hits.transform.tag == "Cubo") // Choca con un cubo hijo
                {
                    //Obtener el cubo que tiene delante
                    _cuboHijoGameObject = hits.transform.gameObject as GameObject;

                    //Como recibe el Raycast, ponemos la variable a true
                    _cuboHijoGameObject.GetComponent<Laser>()._reciboRaycast = true;
                    _cuboHijoGameObject.GetComponent<MeshRenderer>().material = _materialWithEmision;

                }
                else
                {
                    _cuboHijoGameObject.GetComponent<Laser>()._reciboRaycast = false;
                    _cuboHijoGameObject.GetComponent<Laser>()._activarRaycast = false;
                    _cuboHijoGameObject.GetComponent<Laser>().DesactivarLineRender();
                    _cuboHijoGameObject.GetComponent<MeshRenderer>().material = _materialWithoutEmision;
                }

                if (hits.transform.tag != "Cubo")
                {
                    //Desactiva el Line Renderer y el raycast de todos los cubos cuando no colsiona el rayo excepto el ultimo
                    if (_cuboHijoGameObject != null)





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
