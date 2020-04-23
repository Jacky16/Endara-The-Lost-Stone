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
        yield return new WaitForSeconds(.5f);
        _transformDoor.DOLocalMoveY(_transformDoor.localPosition.y - 5, 1);
        yield return new WaitForSeconds(.5f);
        cinemachineVirtualCamera.Priority = 0;
    }
}
