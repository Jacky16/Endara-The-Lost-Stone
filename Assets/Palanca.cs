using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Palanca : MonoBehaviour
{
    [SerializeField] GameObject canvasPalanca;
    [SerializeField] GameObject activateSomething;
    [SerializeField] CinemachineVirtualCamera camera;
    Animator anim;
    private void Start()
    {
        //inputManager = GameObject.Find("Input Manager").GetComponent<InputManager>();
        anim = GetComponent<Animator>();
        canvasPalanca.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasPalanca.SetActive(true);
        }
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        if (InputManager.playerInputs.Player_Keyboard.CatchObject.triggered || InputManager.playerInputs.Player_GamepadXbox.X.triggered)
        {
            anim.SetTrigger("Palanca");
               
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasPalanca.SetActive(false);
        }
    }
    void ActivateBridge()
    {
        StartCoroutine(SwitchCamera());
    }
    IEnumerator SwitchCamera()
    {
        camera.Priority = 10;
        yield return new WaitForSeconds(1);
        SpawnBaldosas[] activateBaldosas = activateSomething.GetComponentsInChildren<SpawnBaldosas>();
        foreach (SpawnBaldosas s in activateBaldosas)
        {
            s.IsSpawingBool(true);
        }
        yield return new WaitForSeconds(4);
        camera.Priority = 0;


    }
}
