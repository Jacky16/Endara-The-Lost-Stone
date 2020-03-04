using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PickUpObjects : MonoBehaviour
{
    [HideInInspector]public GameObject objectToPickup;
    [HideInInspector]public GameObject PickedObject;
    Transform _interactionZone;
    //[SerializeField] GameObject canvasCatchObject;
    //[SerializeField] GameObject canvasThrowObject;
    bool _isCatched;
    bool _isCanvasCatchObject;
    bool _isCanvasThrowObject;



    private void Start()
    {
        _interactionZone = GameObject.FindGameObjectWithTag("TransformObjectPickUp").GetComponent<Transform>();
        _isCanvasCatchObject = false;

    }

    void Update()
    {
        if (objectToPickup != null)
        {
            _isCanvasCatchObject = true;
        }
        else
        {
            _isCanvasCatchObject = false;
            _isCanvasThrowObject = false;
        }

        if (PickedObject != null)
        {
            _isCanvasCatchObject = false;
        }   
    }
    public void PillarElObjeto()
    {
        if (objectToPickup != null && objectToPickup.GetComponent<ObjetoPickeable>().isPickeable == true && PickedObject == null)
        {
            //Pillar el objeto 
                _isCatched = true;
                _isCanvasThrowObject = true;
                PickedObject = objectToPickup;
                PickedObject.GetComponent<ObjetoPickeable>().isPickeable = false;
                PickedObject.transform.SetParent(_interactionZone);
                PickedObject.transform.position = _interactionZone.transform.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
                PickedObject.GetComponent<BoxCollider>().isTrigger = true;
            
                
        }else if(PickedObject != null)
        {
            //Soltar el objeto
            _isCatched = false;
            PickedObject.GetComponent<ObjetoPickeable>().isPickeable = true;
            PickedObject.transform.SetParent(null);
            _isCanvasThrowObject = false;
            PickedObject.GetComponent<Rigidbody>().useGravity = true;
            PickedObject.GetComponent<Rigidbody>().isKinematic = false;
            PickedObject.GetComponent<BoxCollider>().isTrigger = false;
            PickedObject.GetComponent<Rigidbody>().AddForce(Vector3.down * 4);
            PickedObject = null;
            
            
        }

    }
    public void ThrowObject()
    {
        if(_isCatched && PickedObject != null)
        {
            PickedObject.transform.SetParent(null);
            _isCanvasThrowObject = false;
            PickedObject.GetComponent<ObjetoPickeable>().isPickeable = true;
            PickedObject.GetComponent<Rigidbody>().useGravity = true;
            PickedObject.GetComponent<Rigidbody>().isKinematic = false;
            PickedObject.GetComponent<BoxCollider>().isTrigger = true;
            PickedObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward + Camera.main.transform.forward * 25;
            PickedObject.GetComponent<BoxCollider>().isTrigger = false;
            PickedObject = null;

        }


    }
   

    
    public bool CanThrow()
    {
        if (PickedObject.GetComponent<ObjetoPickeable>().isPickeable == true)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Rotate_R(float grades)
    {
        if (objectToPickup.GetComponent<ObjetoPickeable>().isRoteable)
        {
            objectToPickup.transform.DOLocalRotate(new Vector3(0, grades, 0), 0.2f, RotateMode.LocalAxisAdd);
            
        }
        if(PickedObject.GetComponent<ObjetoPickeable>().isRoteable)
        {
            PickedObject.transform.DOLocalRotate(new Vector3(0, grades, 0), 0.2f, RotateMode.LocalAxisAdd);  
        }
    } 
    public void Rotate_L(float grades)
    {
        if (objectToPickup.tag == "Cubo" && objectToPickup.GetComponent<ObjetoPickeable>().isRoteable)
        {
            objectToPickup.transform.DOLocalRotate(new Vector3(0, -grades, 0), 0.2f, RotateMode.LocalAxisAdd);

        }
        else if (PickedObject.tag == "Cubo" && PickedObject.GetComponent<ObjetoPickeable>().isRoteable)
        {
            PickedObject.transform.DOLocalRotate(new Vector3(0, -grades, 0), 0.2f, RotateMode.LocalAxisAdd);
        }

    }
   public bool IsCanvasCatchObject()
   {
        return _isCanvasCatchObject;
   }

    public bool IsCanvasThrowObject()
    {
        return _isCanvasThrowObject;
    }
}