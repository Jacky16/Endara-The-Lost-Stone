using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class SwitchCamera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cameraVirtual;
    private void Start()
    {
        cameraVirtual.Priority = 0;
        cameraVirtual.Follow = null;

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            cameraVirtual.Priority = 11;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            cameraVirtual.Follow = other.transform;
            cameraVirtual.Priority = 11;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            cameraVirtual.Follow = null;
            cameraVirtual.Priority = 0;
        }
    }
}
