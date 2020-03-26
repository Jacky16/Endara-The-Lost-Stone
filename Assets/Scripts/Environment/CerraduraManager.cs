using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class CerraduraManager : MonoBehaviour
{
    [SerializeField] GameObject gameObjectDoor;
    [SerializeField] CinemachineVirtualCamera _camera;
    [SerializeField] bool isKeyInside = false;
    [SerializeField] ParticleSystem particleSystem;
    private void Start()
    {
        _camera.Priority = 0;
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Caja" || other.gameObject.name == "Llave")
        {
            isKeyInside = true;
            StartCoroutine(CameraSwitch(other));
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Caja" || other.gameObject.name == "Llave")
        {


        }
    }


    private void OnTriggerExit(Collider other)
    {
        if ((other.tag == "Caja") || other.gameObject.name == "Llave")
        {
            isKeyInside = false;

        }
    }
    IEnumerator CameraSwitch(Collider other)
    {
        other.GetComponent<ObjetoPickeable>().isPickeable = false;
        yield return new WaitForSeconds(1f);
        _camera.Priority = 10;
        PlayerMovement.canMove = false;
        yield return new WaitForSeconds(2f);
        gameObjectDoor.SetActive(false);
        particleSystem.Play();
        yield return new WaitForSeconds(1f);
        PlayerMovement.canMove = true;
        _camera.Priority = 0;

    }





}
