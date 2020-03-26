using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Laser : MonoBehaviour
{
    LineRenderer _lineRenderer;
    [SerializeField]
    LayerMask _layerMask;

    public Vector3 direction;
    public Vector3 startPoint;
    public enum States { Padre,Hijo};
    public States estados;
    [Header("Bools para combrobar si recibe el Raycast")]
    [SerializeField]
    bool _activarRaycast;
    [SerializeField]
    bool _reciboRaycast;
    GameObject _cuboHijoGameObject;
    [Header("Materiales")]
    [SerializeField]
    Material _materialWithEmision;
    [SerializeField]
    Material _materialWithoutEmision;
    
    Material _currentMaterial;
    [SerializeField]Laser _laser;
    GameObject _gemaPuzzle;
    private void Awake()
    {
        _currentMaterial = GetComponent<MeshRenderer>().material;
        _lineRenderer = GetComponent<LineRenderer>();
    }
    void Start()
    {
        startPoint = new Vector3(0.01f, .4f, 0);
        direction = new Vector3(.1f, .4f, 0);

        if (estados == States.Padre)
        {
            EnableRay();
        }else if(estados == States.Hijo)
        {
            DisableRay();
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<MeshRenderer>().material = _currentMaterial;
        if (estados == States.Padre) //Si soy el padre, el laser siempre estará activado
        {
            EnableRay();
        }

        if (estados == States.Hijo && _reciboRaycast) //Activa el Raycast, si es el cubo hijo y recibe el Raycast
        {
            EnableRay();
        }
        if (estados == States.Hijo && !_reciboRaycast) //Desactiva el Raycast, si es el cubo hijo y no recibe el Raycast
        {
            DisableRay();
            //Desactiva el ultimo cubo
            if(_laser != null)
            {
                _laser.DisableRay();
                _laser._reciboRaycast = false;
                _laser = null;
            }
        }
        if (_activarRaycast) // Si recibo el Raycast, lo activo
        {
            RayBounce();
        }    
    }
    const float lineLenght = 30;
    void RaycastAll()
    {
        if (_activarRaycast)
        {
            Ray ray = new Ray();
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), lineLenght, _layerMask);
            print(hits.Length);
            //Asigno la longitud del LineRenderer
            direction.z = lineLenght;
            float lenghtUntilSolid = lineLenght;
            for (int i = 0; i < hits.Length; i++)
            {
                if (!hits[i].collider.CompareTag("Solution"))
                {
                    if (lenghtUntilSolid > hits[i].distance)
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
                            gemaPuzzle.SolutionInGema(true);
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
                                _cuboHijoGameObject.GetComponent<Laser>().DisableRay();
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
        //if (_activarRaycast)
        //{
        //    Ray ray = new Ray();
        //    RaycastHit hit;
        //    _lineRenderer.SetPosition(0, startPoint);
        //    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, _layerMask))
        //    {
        //        //Calcular la distancia entre el punto mas lejano que esta tocando el Raycast
        //        direction.z = hit.distance;
        //        //Asignar la posicion del Raycast al Linerenderer
        //        _lineRenderer.SetPosition(1, direction);

        //        if (hit.transform.gameObject.tag == "Solution")
        //        {
        //            _listGameObjectsGemaPuzzle.Add(hit.transform.gameObject);

        //            foreach (GameObject g in _listGameObjectsGemaPuzzle) //Para activar todas las gemas
        //            {
        //                g.GetComponent<GemaPuzzle>().Solution(true);
        //                g.GetComponent<Animator>().SetBool("Iluminate", true);
        //            }


        //            //print(_listGameObjectGemaSolution.Count);
        //            //direction.z = hit.distance + Vector3.Distance(transform.position, _listGameObjectGemaSolution[_listGameObjectGemaSolution.Count - 1].transform.position);
        //        }
        //        else
        //        {
        //            if (hit.transform.gameObject.tag != "Solution")
        //            {
        //                if (_listGameObjectsGemaPuzzle.Count > 1)
        //                {
        //                    foreach (GameObject g in _listGameObjectsGemaPuzzle) //Para activar todas las gemas
        //                    {
        //                        g.GetComponent<GemaPuzzle>().Solution(false);
        //                        g.GetComponent<Animator>().SetBool("Iluminate", false);
        //                    }
        //                    _listGameObjectsGemaPuzzle.Clear();
        //                }
        //            }
        //        }


        //        if (hit.transform.tag == "Cubo") // Choca con un cubo hijo
        //        {
        //            //Obtener el cubo que tiene delante
        //            _cuboHijoGameObject = hit.transform.gameObject as GameObject;

        //            //Como recibe el Raycast, ponemos la variable a true
        //            _cuboHijoGameObject.GetComponent<Laser>()._reciboRaycast = true;
        //            _cuboHijoGameObject.GetComponent<MeshRenderer>().material = _materialWithEmision;

        //        }
        //        else
        //        {   
                    
        //        }

        //        if (hit.transform.tag != "Cubo" && hit.collider.gameObject != this.gameObject)
        //        {
        //            //Desactiva el Line Renderer y el raycast de todos los cubos cuando no colsiona el rayo excepto el ultimo
        //            if()
        //                _cuboHijoGameObject.GetComponent<Laser>()._reciboRaycast = false;
        //                _cuboHijoGameObject.GetComponent<Laser>()._activarRaycast = false;
        //                _cuboHijoGameObject.GetComponent<Laser>().DesactivarLineRender();
        //                _cuboHijoGameObject.GetComponent<MeshRenderer>().material = _materialWithoutEmision;
                        
                    
        //            if (!cuboPadre)
        //            {
        //                DesactivarLineRender();
        //            }
        //            //Manera para desactivar el LineRenderer del ultimo cubo
        //            GameObject[] cubos = GameObject.FindGameObjectsWithTag("Cubo");
        //            foreach (GameObject g in cubos)
        //            {
        //                if (!g.GetComponent<Laser>().cuboPadre)
        //                {
        //                    g.GetComponent<Laser>()._reciboRaycast = false;
        //                    g.GetComponent<Laser>()._activarRaycast = false;
        //                    g.GetComponent<Laser>().DesactivarLineRender();
        //                    g.GetComponent<MeshRenderer>().material = _materialWithoutEmision;

        //                }
        //            }
        //            _cuboHijoGameObject = null;
        //        }
        //    }
        //}
    }
    void RayBounce()
    {
        Ray ray = new Ray();
        RaycastHit hit;
       
        _lineRenderer.SetPosition(1, direction);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, _layerMask))
        {
            //Calcular la distancia entre el punto mas lejano que esta tocando el Raycast
            _lineRenderer.SetPosition(0, startPoint);
            //Asignar la posicion del Raycast al Linerenderer
            direction.z = hit.distance;

            //Si tiene el tag "Cubo", tiene el componente Laser y no es el mismo cubo
            if (hit.collider.gameObject.CompareTag("Cubo") && hit.collider.gameObject.GetComponent<Laser>() && hit.collider.gameObject != gameObject)
            {
                _laser = hit.collider.gameObject.GetComponent<Laser>();
                _laser.EnableRay();
                _laser._reciboRaycast = true;
                
            }
            else if(!hit.collider.gameObject.CompareTag("Cubo") && !hit.collider.gameObject.GetComponent<Laser>())
            {
                if(_laser != null)
                {
                    _laser.DisableRay();
                    _laser._reciboRaycast = false;
                    _laser = null;
                    return;
                }
               
            }

            if (hit.transform.gameObject.tag == "Solution")
            {
                SolutionTrue(hit.collider.gameObject);
                return;
            }
            else if (hit.transform.gameObject.tag != "Solution")
            {
                if(_gemaPuzzle != null)
                {
                    SolutionFalse();
                }
                
                return;
            }
            
        }
    }
    void SolutionTrue( GameObject g)
    {
        if(TryGetComponent(out ObjetoPickeable p))
        {
            p.enabled = false;
        }
        _gemaPuzzle = g;
        GemaPuzzle gemaPuzzle = _gemaPuzzle.GetComponent<GemaPuzzle>();
        Animator anim = _gemaPuzzle.GetComponent<Animator>();
        MeshRenderer meshRenderer = _gemaPuzzle.GetComponent<MeshRenderer>();
        meshRenderer.material.SetFloat("Alpha", 2);
        gemaPuzzle.SolutionInGema(true);
        anim.SetBool("Iluminate", true);
    }
    void SolutionFalse()
    {
        GemaPuzzle gemaPuzzle = _gemaPuzzle.GetComponent<GemaPuzzle>();
        Animator anim = _gemaPuzzle.GetComponent<Animator>();

        gemaPuzzle.SolutionInGema(false);
        anim.SetBool("Iluminate", false);
    }
    public void EnableRay()
    {
        _activarRaycast = true;
        _lineRenderer.enabled = true;
        _currentMaterial = _materialWithEmision;
    }
    public void DisableRay()
    {
        _activarRaycast = false;
        _lineRenderer.enabled = false;
        _currentMaterial = _materialWithoutEmision;

    }

}
