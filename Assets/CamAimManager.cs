using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CamAimManager : MonoBehaviour
{
    InputManager inputManager;
    [SerializeField]
    CinemachineVirtualCamera cameraAim_R;
    [SerializeField]
    CinemachineVirtualCamera cameraAim_L;
    void Start()
    {
        inputManager = GameObject.Find("Input Manager").GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CameraAimManager()
    {
        if (inputManager.IsRightClickMousePressed())
        {
            cameraAim_R.Priority = 10;
        }
        else
        {
            cameraAim_R.Priority = 0;

        }
    }
}
