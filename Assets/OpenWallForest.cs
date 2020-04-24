using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenWallForest : MonoBehaviour
{
    [SerializeField] GameObject gameObjectDoor;
    [SerializeField] CinemachineVirtualCamera _camera;
    bool isKeyInside = false;
    private void Start()
    {
        _camera.Priority = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Caja" || other.gameObject.name == "Llave" && !isKeyInside)
        {
            isKeyInside = true;
            StartCoroutine(CameraSwitch(other));
        }
    }
    



   
    IEnumerator CameraSwitch(Collider other)
    {

        yield return new WaitForSeconds(1f);
        _camera.Priority = 10;
        other.GetComponent<ObjetoPickeable>().enabled = false;
        PlayerMovement.canMove = false;

        yield return new WaitForSeconds(2f);
        gameObjectDoor.SetActive(false);

        yield return new WaitForSeconds(1f);

        PlayerMovement.canMove = true;
        _camera.Priority = 0;

    }
}
