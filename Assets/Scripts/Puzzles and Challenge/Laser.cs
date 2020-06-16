using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;

public class Laser : MonoBehaviour
{
    //Line renderer
    LineRenderer _lineRenderer;
    //Layer Mask
    [SerializeField]
    LayerMask _layerMask;

    //Vectores
    public Vector3 direction;
    public Vector3 startPoint;
    Quaternion _lastRotation;
    //Estados
    public enum States { Padre,Hijo};
    public States estados;
    //Variables booleanas
    [Header("Bools para combrobar si recibe el Raycast")]
    [SerializeField]
    bool _activarRaycast;
    [SerializeField]
    bool _reciboRaycast;

    //Variables Materiales
    [Header("Materiales")]
    [SerializeField]
    Material _materialWithEmision;
    [SerializeField]
    Material _materialWithoutEmision;
    Material _currentMaterial;

    //Laser next Cubo
    Laser _laser;

    //Gema Solution
    GameObject _gemaPuzzle;

    //Particle logic
    [SerializeField]
    GameObject particleSystem;
    Vector3 distanceParticle;

    //Audio
  
    [SerializeField]
    AudioSource _audioSourceLaserActive;

    [SerializeField]
    AudioSource _audioSourceLaserIdle;

    bool isPlayedSound = false;
    bool canSnap = false;

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
            //Asignar la posicion del Raycast a la particula
            distanceParticle.z = hit.distance;
            particleSystem.transform.localPosition = distanceParticle;
            //Si tiene el tag "Cubo", tiene el componente Laser y no es el mismo cubo
            if (hit.collider.gameObject.CompareTag("Cubo") && hit.collider.gameObject.GetComponent<Laser>() && hit.collider.gameObject != gameObject)
            {
                canSnap = true;
                _laser = hit.collider.gameObject.GetComponent<Laser>();
                _laser.EnableRay();
                _laser._reciboRaycast = true;
                
                
                SnapRotation(transform.localRotation.eulerAngles);
                
                _laser.PlayLaserSound();
                    
            }
            else if(!hit.collider.gameObject.CompareTag("Cubo") && !hit.collider.gameObject.GetComponent<Laser>())
            {
                canSnap = false;
                if (_laser != null)
                {
                    _laser.DisableRay();
                    _laser._reciboRaycast = false;
                    _laser = null;
                    isPlayedSound = false;
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

        GameObject [] op = GameObject.FindGameObjectsWithTag("Cubo");

        foreach(GameObject go in op)
        {
            ObjetoPickeable ob;
            if (go.TryGetComponent<ObjetoPickeable>(out ob))
            {
                ob.isRoteable = false;
            }
            Laser laser;
            if(go.TryGetComponent<Laser>(out laser))
            {
                laser.SaveRotation();
            }
        }
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
        particleSystem.SetActive(true);
        if (!_audioSourceLaserIdle.isPlaying)
        {
            _audioSourceLaserIdle.Play();
        }
        
    }
    public void SaveRotation()
    {
        _lastRotation = transform.localRotation;
    }
    public void LoadRotation( Quaternion r)
    {
        transform.localRotation = r;
    }
    public void DisableRay()
    {
        _activarRaycast = false;
        _lineRenderer.enabled = false;
        particleSystem.SetActive(false);
        _currentMaterial = _materialWithoutEmision;
        _audioSourceLaserIdle.Stop();
    }

    void SnapRotation(Vector3 currentRotation)
    {   
        if(estados == States.Hijo)
        {

            transform.DOLocalRotate(currentRotation, 2).Kill(canSnap);
        }

    }
    public void PlayLaserSound()
    {
        if (!isPlayedSound)
        {
            //_audioSource.Play();
            _audioSourceLaserActive.Play();
            isPlayedSound = true;
        }

    }
}
