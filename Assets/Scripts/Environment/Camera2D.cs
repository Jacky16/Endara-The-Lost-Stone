using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class Camera2D : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cameraVirtual;
    [SerializeField]
    Transform cv_OrinalPositon;
    [SerializeField]
    Transform center2D;
    private void Start()
    {
        cameraVirtual.Priority = 0;
        cameraVirtual.enabled = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.name == "Player")
        {
            StartCoroutine(SwitchToEnableCamera(other));
            PlayerMovement pm = other.GetComponent<PlayerMovement>();
            pm.enabled = false;
            other.transform.DOMoveZ(center2D.position.z, .1f).SetEase(Ease.Linear).OnComplete(() => pm.enabled = true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" || other.name == "Player")
        {
            cameraVirtual.Priority = 11;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player" || other.CompareTag("Player"))
        {
            StartCoroutine(SwitchToDisableCamera(other));

        }
    }
    public void ResetPosition()
    {
        StartCoroutine(DelayResetPositionCV());
    }
    public IEnumerator DelayResetPositionCV()
    {
        yield return new WaitForSeconds(1.5f);
        cameraVirtual.Priority = 0;
        cameraVirtual.Follow = cv_OrinalPositon;
    }


    IEnumerator SwitchToEnableCamera(Collider other)
    {
        yield return new WaitForSeconds(1f);
        other.GetComponent<PlayerMovement>().SetPlayer2D(true);
        cameraVirtual.gameObject.SetActive(true);
        cameraVirtual.enabled = true;
        cameraVirtual.Priority = 11;
        yield return new WaitForSeconds(1);
        cameraVirtual.Follow = other.transform;
    }
    IEnumerator SwitchToDisableCamera(Collider other)
    {
        other.GetComponent<PlayerMovement>().SetPlayer2D(false);
        yield return new WaitForSeconds(0.5f);
        cameraVirtual.Follow = null;
        cameraVirtual.Priority = 0;
        cameraVirtual.enabled = false;
        cameraVirtual.gameObject.SetActive(false);
        
    }
}
