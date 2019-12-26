using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;


public class PickUpObjects : MonoBehaviour
{
    [HideInInspector]public GameObject objectToPickup;
    [HideInInspector]public GameObject PickedObject;
    Transform interactionZone;
    [SerializeField] GameObject canvasCatchObject;
    [SerializeField] GameObject canvasThrowObject;



    private void Start()
    {
        interactionZone = GameObject.FindGameObjectWithTag("TransformObjectPickUp").GetComponent<Transform>();
        canvasCatchObject.SetActive(false);

    }

    void Update()
    {
        if (objectToPickup != null)
        {
            canvasCatchObject.SetActive(true);
        }
        else
        {
            canvasCatchObject.SetActive(false);
            canvasThrowObject.SetActive(false);
        }

        if (PickedObject != null)
        {
            canvasCatchObject.SetActive(false);
        }   
    }
    public void PillarElObjeto()
    {
        if (objectToPickup != null && objectToPickup.GetComponent<ObjetoPickeable>().isPickeable == true && PickedObject == null)
        {
            
                canvasThrowObject.SetActive(true);

                Debug.Log("He pillado el objeto");
                PickedObject = objectToPickup;
                PickedObject.GetComponent<ObjetoPickeable>().isPickeable = false;
                PickedObject.transform.SetParent(interactionZone);
                PickedObject.transform.position = interactionZone.transform.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
                PickedObject.GetComponent<BoxCollider>().isTrigger = true;
            
                
        }else if(PickedObject != null)
        {
           
                PickedObject.GetComponent<ObjetoPickeable>().isPickeable = true;
                PickedObject.transform.SetParent(null);
                canvasThrowObject.SetActive(false);

                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject.GetComponent<BoxCollider>().isTrigger = false;
                PickedObject.GetComponent<Rigidbody>().AddForce(Vector3.down * 4);


                PickedObject = null;
            
            
        }

    }
    public void ThrowObject()
    {
        StartCoroutine(ThrowObjectCoroutine());
    }
   

    IEnumerator ThrowObjectCoroutine()
    {
        PickedObject.transform.SetParent(null);
        //PickedObject = null;
        canvasThrowObject.SetActive(false);

        PickedObject.GetComponent<ObjetoPickeable>().isPickeable = true;
        PickedObject.GetComponent<Rigidbody>().useGravity = true;
        PickedObject.GetComponent<Rigidbody>().isKinematic = false;
        PickedObject.GetComponent<BoxCollider>().isTrigger = true;
        PickedObject.GetComponent<Rigidbody>().velocity = gameObject.transform.forward + transform.forward * 25;
        //AddForce(, ForceMode.Impulse);
        yield return new WaitForSeconds(0.1f);
        PickedObject.GetComponent<BoxCollider>().isTrigger = false;
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
    
   
}