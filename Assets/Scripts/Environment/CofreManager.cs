using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class CofreManager : MonoBehaviour
{
    Animator anim;
    bool isOpen = false;
    [SerializeField]
    ParticleSystem particleSystem;
    [SerializeField]
    Light light;
    UIManager uIManager;
    public UnityEvent onOpen;
    AudioSource audioSource;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        uIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
    private void Start()
    {
        light.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isOpen)
            {
                uIManager.AnimationScaleActiveButtonOpen(); //Activar boton de abrir
                
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (InputManager.playerInputs.PlayerInputs.CatchObject.triggered && !isOpen)
            {
                other.GetComponent<Animator>().SetTrigger("Open");
                anim.SetTrigger("Open");
                audioSource.Play(); // Sonido del cofre abbriendose
                isOpen = true;
            }
        }
    }
    void Opened()
    {
        onOpen.Invoke();
    }
    public void ParticleCoins()
    {
        particleSystem.Play();
        light.enabled = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uIManager.AnimationScaleDisableButtonOpen();//Desctivar boton de cerrar
        }
    } 
    public void Close()
    {
        anim.SetTrigger("Close");
    }
}
