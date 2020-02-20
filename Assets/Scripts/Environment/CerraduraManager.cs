using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class CerraduraManager : MonoBehaviour
{
    [SerializeField] GameObject gameObjectDoor;
    [SerializeField] CinemachineVirtualCamera camera;

   

    [SerializeField] bool isKeyInside = false;
    bool tweenComplete;

   
    private void Start()
    {
       
       
       
    }
    private void Update()
    {
        if (isKeyInside)
        {
            StartCoroutine(CameraSwitch());

        }
        else
        {

            gameObjectDoor.SetActive(true);

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Caja" || other.gameObject.name == "Llave")
        {
            isKeyInside = true;
        }
       
    }


    private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Caja") || other.gameObject.name == "Llave")
        {
            isKeyInside = false;
        }
    }
    IEnumerator CameraSwitch() 
    {
        camera.Priority = 10;
        yield return new WaitForSeconds(1);
        gameObjectDoor.SetActive(false);


    }





}
