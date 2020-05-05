using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLevel : MonoBehaviour
{
    [Range(0, 50)] public float rayLenght;
    //Line renderer
    LineRenderer _lineRenderer;
    //Layer Mask
    [SerializeField]
    LayerMask _layerMask;

    //Vectores
    public Vector3 direction;
    public Vector3 startPoint;
   
    //Variables booleanas
    [Header("Bools para combrobar si recibe el Raycast")]


    //Particle logic
    [SerializeField]
    GameObject particleSystem;
    Vector3 distanceParticle;

    //Audio
    [SerializeField]
    AudioSource _audioSourceLaserIdle;

    [SerializeField]
    bool isRotating;

    [SerializeField]
    bool rotationInverted;

    [SerializeField]
    float speedRotation;
    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        startPoint = new Vector3(0.01f, .4f, 0);
        direction = new Vector3(.1f, .4f, 0);
        direction.z = rayLenght;
        RayBounce();
    }
    private void Start()
    {
        _lineRenderer.SetPosition(0, startPoint);
        if (isRotating)
        {
            if (rotationInverted)
            {
                transform.DORotate(new Vector3(0, 0, -360), speedRotation, RotateMode.WorldAxisAdd).SetLoops(-1).SetEase(Ease.Linear);

            }
            else
            {
                transform.DORotate(new Vector3(0, 0, 360), speedRotation, RotateMode.WorldAxisAdd).SetLoops(-1).SetEase(Ease.Linear);

            }
        }

    }

    private void FixedUpdate()
    {
        RayBounce();
    }
    void RayBounce()
    {
        Ray ray = new Ray();
        RaycastHit hit;
        _lineRenderer.SetPosition(1, direction);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayLenght, _layerMask))
        {
            //Calcular la distancia entre el punto mas lejano que esta tocando el Raycast
            //Asignar la posicion del Raycast al Linerenderer
            direction.z = hit.distance;
            //Asignar la posicion del Raycast a la particula
            distanceParticle.z = hit.distance;
            particleSystem.transform.localPosition = distanceParticle;

            if(hit.collider != null)
            {
                if(hit.collider.gameObject.name == "Player")
                {
                    hit.collider.GetComponent<PlayerLifeManager>().SubstractLife();
                    hit.collider.GetComponent<PlayerMovement>().SetPlayer2D(false);
                }
            }
        }
        else
        {
            direction.z = rayLenght;
            distanceParticle.z = rayLenght;

        }
    }
}
