using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GodManager : MonoBehaviour
{
    [SerializeField] GameObject canvasModeGod;
    public float unitsGravityModeGod;
    [SerializeField]
    Transform playerTransform;

    private void Start()
    {
        unitsGravityModeGod = 5;
        canvasModeGod.SetActive(false);

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            PlayerMovement.isModeGod = !PlayerMovement.IsModeGod();
        }
        
        if (PlayerMovement.IsModeGod())
        {
            canvasModeGod.SetActive(true);

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            playerTransform.name = "Mode God";

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F2))
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                playerTransform.name = "Player";
                canvasModeGod.SetActive(false);
            }
        }

    }
    public void Teleport(Transform tpPosition)
    {
        if(tpPosition != null)
        {
            CharacterController cc = playerTransform.GetComponent<CharacterController>();
            cc.enabled = false;
            playerTransform.position = tpPosition.position;
            cc.enabled = true;
            print(tpPosition.name);
        }
    }
    public float UnitsToJumpInModeGod()
    {
        return unitsGravityModeGod;
    }
   
  
    


}
