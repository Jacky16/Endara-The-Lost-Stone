using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Linq.Expressions;

public class KeyPlattformChallenge : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera _virtualCamera;

    [SerializeField]
    GameObject _gameObjectExit;

    [SerializeField]
    ZonaSaltosManager _zonaSaltosManager;
    private void Start()
    {
        _gameObjectExit.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ActiveDoor());
    }
    IEnumerator ActiveDoor()
    {
        _virtualCamera.Priority = 10;
        _zonaSaltosManager.DisableGravityPlattforms();

        yield return new WaitForSeconds(2);

        _gameObjectExit.SetActive(true);
        PlayerMovement.canMove = false;

        yield return new WaitForSeconds(2);

        _virtualCamera.Priority = 0;
        PlayerMovement.canMove = true;
        _zonaSaltosManager.ActivateGravityPlattforms();
        gameObject.SetActive(false);
    }
}
