using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class SolutionPuzzle3 : MonoBehaviour
{
    [SerializeField] GameObject gameObjectDoor;
    [SerializeField] CinemachineVirtualCamera _camera;
    [SerializeField] bool isKeyInside = false;
    private void Start()
    {
        _camera.Priority = 0;
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Caja" || other.gameObject.name == "Llave")
        {
            isKeyInside = true;
            other.transform.SetParent(transform);
            other.transform.DOLocalMove(Vector3.zero, 1).OnComplete(() => StartCoroutine(CameraSwitch(other)));
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
        
        yield return new WaitForSeconds(1f);
        _camera.Priority = 10;
        PlayerMovement.canMove = false;

        yield return new WaitForSeconds(2f);
        gameObjectDoor.transform.DOMoveY(gameObjectDoor.transform.position.y - 8, 1);

        yield return new WaitForSeconds(1f);

        PlayerMovement.canMove = true;
        _camera.Priority = 0;

    }





}
