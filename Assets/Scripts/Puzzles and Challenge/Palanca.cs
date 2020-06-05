using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Palanca : MonoBehaviour
{
    [SerializeField]
    GameObject [] _activateBridge;

    [SerializeField]
    CinemachineVirtualCamera cameraBridge;

    Animator anim;

    AudioSource _audioSource;
    UIManager uIManager;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uIManager.AnimationScaleActiveButtonUse();
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
            uIManager.AnimationScaleDisableButtonUse();
        }
    }
    void ActivateBridge() // Se ejecuta en la animacion de la palanca
    {
        StartCoroutine(SwitchCamera());
    }
    IEnumerator SwitchCamera()
    {
        cameraBridge.Priority = 10;
        uIManager.AnimationScaleDisableButtonUse();
        yield return new WaitForSeconds(1);
        foreach (GameObject s in _activateBridge)
        {
            s.GetComponent<SpawnBaldosas>().IsSpawingBool(true);
        }
        yield return new WaitForSeconds(4);
        cameraBridge.Priority = 0;
    }
    public void PlaySound()
    {
        _audioSource.Play();
    }
   
}
