using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class CerraduraManager : MonoBehaviour
{
    [SerializeField] GameObject gameObjectDoor;
    //[SerializeField] CinemachineVirtualCamera camera;

   

    [SerializeField] bool isKeyInside = false;
    bool tweenComplete;

   
    private void Start()
    {
        //camera.Priority = 0;



    }
    private void Update()
    {
        if (isKeyInside)
        {

        }
        else
        {

            gameObjectDoor.SetActive(true);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Caja" || other.gameObject.name == "Llave")
        {
            isKeyInside = true;
            //StartCoroutine(CameraSwitch(other));
        }

        if (other.CompareTag("Solution"))
        {
            Destroy(gameObjectDoor);

        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Caja" || other.gameObject.name == "Llave")
        {
            other.GetComponent<ObjetoPickeable>().enabled = false;


        }
    }


    private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Caja") || other.gameObject.name == "Llave")
        {
            isKeyInside = false;

        }
    }
    //IEnumerator CameraSwitch(Collider other)
    //{
    //    yield return new WaitForSeconds(1f);

    //    camera.Priority = 10;
    //    yield return new WaitForSeconds(0.5f);
    //    gameObjectDoor.SetActive(false);
    //    yield return new WaitForSeconds(1f);

    //    camera.Priority = 0;

    //}





}
