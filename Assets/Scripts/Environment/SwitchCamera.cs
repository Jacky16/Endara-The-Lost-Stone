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
        cameraVirtual.enabled = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(SwitchToEnableCamera(other));
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            cameraVirtual.Priority = 11;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(SwitchToDisableCamera(other));

        }
    }

    IEnumerator SwitchToEnableCamera(Collider other)
    {
        cameraVirtual.enabled = true;
        cameraVirtual.Priority = 11;
        yield return new WaitForSeconds(1);
        cameraVirtual.Follow = other.transform;
    }
    IEnumerator SwitchToDisableCamera(Collider other)
    {
        cameraVirtual.Follow = null;
        cameraVirtual.Priority = 0;
        cameraVirtual.enabled = false;
        yield return null;
    }
}
