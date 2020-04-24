using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GodManager : MonoBehaviour
{
    PlayerMovement playerMovement;
   

    private void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
           playerMovement.isGod = !playerMovement.isGod;
        }
        if (playerMovement.isGod)
        {
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
           
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F10))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            
        }
        
    }
    
    


}
