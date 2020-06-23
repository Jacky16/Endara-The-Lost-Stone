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
    GameObject currentWall;

    [SerializeField]
    ZonaSaltosManager _zonaSaltosManager;

    AudioSource audioSource;
    [SerializeField]
    AudioClip pickUpKeyAudio;

    bool isKeyPicked = false;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        audioSource.Play();
        _gameObjectExit.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && !isKeyPicked)
        {
            isKeyPicked = true;
            StartCoroutine(ActiveDoor());
        }
        
        
    }
    IEnumerator ActiveDoor()
    {
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.PlayOneShot(pickUpKeyAudio);
        _virtualCamera.Priority = 10;
        PlayerMovement.canMove = false;
        _zonaSaltosManager.DisableGravityPlattforms();

        yield return new WaitForSeconds(2);

        _gameObjectExit.SetActive(true);
        currentWall.SetActive(false);
        PlayerMovement.canMove = false;

        yield return new WaitForSeconds(2);

        PlayerMovement.canMove = true;
        _virtualCamera.Priority = 0;
        PlayerMovement.canMove = true;
        _zonaSaltosManager.ActivateGravityPlattforms();
        gameObject.SetActive(false);
    }
}
