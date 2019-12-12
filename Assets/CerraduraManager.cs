using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class CerraduraManager : MonoBehaviour
{
    [SerializeField] Transform gameObjectDoor;
 
    [SerializeField] GameObject gameObjectLightDoor;

    MeshRenderer meshRendererLightDoor;
    Light areaLightDoor;
    Light lightCerradura;

    [SerializeField] bool isKeyInside = false;
    bool tweenComplete;

    [SerializeField]Material materialLightDoorOpen;
    [SerializeField]Material materialLightDoorClose;
    private void Start()
    {
        //Cerradura componentes
        lightCerradura = GetComponentInChildren<Light>();
        //Puerta componentes
        areaLightDoor = gameObjectLightDoor.GetComponentInChildren<Light>();
        meshRendererLightDoor = gameObjectLightDoor.GetComponent<MeshRenderer>();
        DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(500, 10);
    }
    private void Update()
    {
        if (isKeyInside)
        {
            gameObjectDoor.transform.DOLocalMoveY(4, 2).SetEase(Ease.Linear);
            DOTween.Complete(gameObjectDoor, tweenComplete = true);
            //Cambiar el color de la luz de la cerradura
            lightCerradura.color = Color.green;
            //Cambiar el color de emisive del objeto luz
            meshRendererLightDoor.material = materialLightDoorOpen;
            //Cambiar el color de la luz de la area light de la luz de la puerta
            areaLightDoor.color = Color.green;
        }
        else
        {
            gameObjectDoor.transform.DOLocalMoveY(0, 2);
            //Cambiar el color de la luz de la cerradura
            lightCerradura.color = Color.red;
            //Cambiar el color de emisive del objeto luz
            meshRendererLightDoor.material = materialLightDoorClose;
            //Cambiar el color de la luz de la area light de la luz de la puerta
            areaLightDoor.color = Color.red;



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
    IEnumerator Boxdestroy() 
    {
        
        yield return new WaitForSeconds(2);
        isKeyInside = false;
        

    }





}
