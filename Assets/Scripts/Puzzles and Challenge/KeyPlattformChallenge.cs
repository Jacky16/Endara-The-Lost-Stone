using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Linq.Expressions;
using UnityEngine.InputSystem;

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
    [SerializeField]
    AudioClip keyAudio;

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

        _zonaSaltosManager.ActivateGravityPlattforms();

        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        isKeyPicked = false;
        audioSource.playOnAwake = true;
        audioSource.loop = true;
        audioSource.PlayOneShot(keyAudio);
    }
}
