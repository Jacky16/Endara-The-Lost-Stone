using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Palanca : MonoBehaviour
{
    [SerializeField]
    GameObject [] _activateBridge;

    [SerializeField]
    CinemachineVirtualCamera camera;

    [SerializeField]
    Animator anim;
    bool _isInPalanca;

    AudioSource _audioSource;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.SetPlayerPalanca(true);
        }      
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (InputManager.playerInputs.PlayerInputs.CatchObject.triggered)
            {
                anim.SetTrigger("Palanca");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.SetPlayerPalanca(false);
        }
    }
    void ActivateBridge() // Se ejecuta en la animacion
    {
        StartCoroutine(SwitchCamera());
    }
    IEnumerator SwitchCamera()
    {
        camera.Priority = 10;
        _isInPalanca = false;
        yield return new WaitForSeconds(1);
        foreach (GameObject s in _activateBridge)
        {
            s.GetComponent<SpawnBaldosas>().IsSpawingBool(true);
        }
        yield return new WaitForSeconds(4);
        camera.Priority = 0;
    }
    public void PlaySound()
    {
        _audioSource.Play();
    }
    public bool PlayerInPalanca()
    {
        return _isInPalanca;
    }
}
