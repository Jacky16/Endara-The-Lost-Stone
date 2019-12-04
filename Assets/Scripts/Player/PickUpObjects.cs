using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    public GameObject objectToPickup;
    public GameObject PickedObject;
    Transform interactionZone;


    private void Start()
    {
        interactionZone = GameObject.FindGameObjectWithTag("InteractionZone").GetComponent<Transform>();
    }
    void Update()
    {

        catchObjjects();

            
        
    }

    public void catchObjjects()
    {
        if (objectToPickup != null && objectToPickup.GetComponent<ObjetoPickeable>().isPickeable == true && PickedObject == null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject = objectToPickup;
                PickedObject.GetComponent<ObjetoPickeable>().isPickeable = false;
                PickedObject.transform.SetParent(interactionZone);
                PickedObject.transform.position = interactionZone.transform.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        else if (PickedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                
                PickedObject.GetComponent<ObjetoPickeable>().isPickeable = true;
                PickedObject.transform.SetParent(null);

                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject = null;
            }
        }

        //Throw  Object 
        if (Input.GetMouseButtonDown(0) && PickedObject != null)
        {
            StartCoroutine(ThrowObject());

            Debug.Log("Lo he lanzado");
        }
    }
    
    IEnumerator ThrowObject()
    {
        PickedObject.transform.SetParent(null);

        PickedObject.GetComponent<ObjetoPickeable>().isPickeable = true;
        PickedObject.GetComponent<Rigidbody>().useGravity = true;
        PickedObject.GetComponent<Rigidbody>().isKinematic = false;
        PickedObject.GetComponent<BoxCollider>().isTrigger = true;
        PickedObject.GetComponent<Rigidbody>().AddForce(interactionZone.forward + transform.forward * 20, ForceMode.Impulse);
        yield return new WaitForSeconds(0.1f);
        PickedObject.GetComponent<BoxCollider>().isTrigger = false;
    }
}
