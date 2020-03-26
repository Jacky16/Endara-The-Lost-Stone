using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CofreManager : MonoBehaviour
{
    Animator anim;
 
    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //if (InputManager.playerInputs.Player_Keyboard.CatchObject.triggered || InputManager.playerInputs.Player_GamepadXbox.X.triggered && !isInCanvas)
            //{
            //    anim.SetTrigger("Open");
            //}
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
    
   
}
