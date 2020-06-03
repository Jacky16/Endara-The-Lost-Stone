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

    public UnityEvent onOpen;
    private void Awake()
    {
        anim = GetComponent<Animator>();  
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
                UIManager.SetPlayerCofre(true);
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
            UIManager.SetPlayerCofre(false);
        }
    } 
    public void Close()
    {
        anim.SetTrigger("Close");
    }
}
