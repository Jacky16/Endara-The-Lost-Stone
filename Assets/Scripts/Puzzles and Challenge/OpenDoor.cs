using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    Transform _transformDoor;

    [SerializeField]
    CinemachineVirtualCamera cinemachineVirtualCamera;
    
    public void OpenDoorAnimation()
    {
        StartCoroutine(CoroutineDoorAnimation());
    }
    IEnumerator CoroutineDoorAnimation()
    {
        cinemachineVirtualCamera.Priority = 10;
        yield return new WaitForSeconds(1.5f);
        _transformDoor.DOMoveY(_transformDoor.transform.position.y - 5, 1);
        yield return new WaitForSeconds(1f);
        cinemachineVirtualCamera.Priority = 0;
    }
}
