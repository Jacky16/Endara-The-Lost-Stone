using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Referencias Scripts")]
    [SerializeField]
    InputManager inputManager;
    [SerializeField]
    PickUpObjects pickUpObjects;
    [Header("PC")]

    [Header("Canvas Catch/Rotate Object")]
    [SerializeField]
    GameObject canvasCatchObject;
    [SerializeField]
    GameObject canvasThrowObject;

    [Header("Xbox")]
    [SerializeField]
    GameObject canvasCatchObjectXbox;
    [SerializeField]
    GameObject canvasThrowObjectXbox;

    private void Update()
    {
        if (inputManager.useGamepad) //Use Gamepad
        {
            if (pickUpObjects.IsCanvasCatchObject())
            {
                canvasCatchObject.SetActive(true);
            }
            else
            {
                canvasCatchObject.SetActive(false);
            }
            if (pickUpObjects.IsCanvasThrowObject())
            {
                canvasThrowObject.SetActive(true);
            }
            else
            {
                canvasThrowObject.SetActive(false);
            }
        }
        else // Use Keyboard
        {
            if (pickUpObjects.IsCanvasCatchObject())
            {
                canvasCatchObjectXbox.SetActive(true);
            }
            else
            {
                canvasCatchObjectXbox.SetActive(false);
            }
            if (pickUpObjects.IsCanvasThrowObject())
            {
                canvasThrowObjectXbox.SetActive(true);
            }
            else
            {
                canvasThrowObjectXbox.SetActive(false);
            }
        }
    }

}
