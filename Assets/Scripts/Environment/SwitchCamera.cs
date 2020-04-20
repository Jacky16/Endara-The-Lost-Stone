using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField]
    bool _followPlayer;

    [SerializeField]
    bool _lookAtPlayer;

    public UnityEvent onCameraChange;
    bool _playerIsInside;
    private void Start()
    {
        if(onCameraChange == null)
        {
            onCameraChange = new UnityEvent();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onCameraChange.Invoke();
            _playerIsInside = true;
        }

    }
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
            _playerIsInside = false;
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
    public bool PlayerIsInside()
    {
        return _playerIsInside;
    }
    
}
