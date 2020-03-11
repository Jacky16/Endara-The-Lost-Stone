using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Referencias Scripts")]
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

    private void Start()
    {
        canvasCatchObjectXbox.SetActive(false);
        canvasThrowObjectXbox.SetActive(false);
    }
    private void Update()
    {
        if (InputManager.useGamepad)
        {
            if (pickUpObjects.IsCanvasCatchObject())
            {
                canvasCatchObjectXbox.SetActive(true);
            }
            else
            {
                canvasCatchObjectXbox.SetActive(false);
            }
        }
        else
        {

        }

    }

}
