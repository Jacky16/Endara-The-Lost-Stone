using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInputManager : MonoBehaviour
{
    [Header("Referencias Scripts")]
    [SerializeField]
    PickUpObjects pickUpObjects;
    [Header("Canvas XBOX")]
    [SerializeField]
    GameObject _canvasThrowObject_Xbox;
    [SerializeField]
    GameObject _canvasCatchObject_Xbox;


    private void Update()
    {
        UIManager();
    }
    void UIManager()
    {
        if (InputManager.useGamepad)
        {
            if (pickUpObjects.IsCanvasCatchObject())
            {
                _canvasThrowObject_Xbox.SetActive(false);
                _canvasCatchObject_Xbox.SetActive(true);
            }
            if (pickUpObjects.IsCanvasThrowObject())
            {
                _canvasThrowObject_Xbox.SetActive(true);
                _canvasCatchObject_Xbox.SetActive(false);
            }
        }
        else
        {
            if (pickUpObjects.IsCanvasCatchObject())
            {

            }
            if (pickUpObjects.IsCanvasThrowObject())
            {

            }
        }
    }

}
