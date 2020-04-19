using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField]
    bool _followPlayer;
    [SerializeField]
    bool _lookAtPlayer;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cinemachineVirtualCamera.Priority = 10;
            if (_followPlayer)
            {
                cinemachineVirtualCamera.Follow = other.transform;
            }
            if (_lookAtPlayer)
            {
                cinemachineVirtualCamera.LookAt = other.transform;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cinemachineVirtualCamera.Priority = 0;
            if (_followPlayer)
            {
                cinemachineVirtualCamera.Follow = null;
            }
            if (_lookAtPlayer)
            {
                cinemachineVirtualCamera.LookAt = null;
            }
        }
    }
}
