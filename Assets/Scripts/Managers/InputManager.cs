using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
public class  InputManager : MonoBehaviour
{
    [SerializeField] PlayerMovement _player;
    [SerializeField] PickUpObjects _pickUpsObjects;
    [SerializeField] CinemachineFreeLook _freeLookCamera;
    public static InputsPlayer playerInputs;
    public PlayerInput playerInput;
    //Variables bools para los controles de movimiento
    bool isJostickLeftPressed;
    bool isJostickRightPressed;
    bool isWASDIsPressed;
    //Variables bool para los controles de interaccion
    bool canJump;
    bool isMouseRightClickPressed;
    bool isButtonGampedadAimPressed;
    Vector2 vector2Axis;
    public static bool useGamepad;

    private Vector2 LookCamera; // your LookDelta
    public float deadZoneX = 0.2f;



    public enum ControlsState { PS4,Xbox,KeyBoard};
    public static ControlsState controlsState;
    private void Awake()
    {
        playerInputs = new InputsPlayer();
        playerInput = GetComponent<PlayerInput>();
       
        playerInputs.PlayerInputs.MovementCamera.performed += ctx => LookCamera = ctx.ReadValue<Vector2>().normalized;
        playerInputs.PlayerInputs.MovementCamera.performed += ctx => GetInput();
        playerInputs.PlayerInputs.MovementCamera.canceled += ctx => LookCamera = Vector3.zero;

    }
    private void Update()
    {
        switch (playerInput.currentControlScheme)
        {
            case "PS4":
                print("PS4");
                break;
            case "Xbox":
                print("Xbox");
                break;
            case "KeyboardMouse":
                print("KeyboardMouse");
                break;
        }

        if (playerInputs.PlayerInputs.CatchObject.triggered) //Catch object
        {
            _pickUpsObjects.PillarElObjeto();
        }
        //Rotate Object L
        if (playerInputs.PlayerInputs.RotationObject_L.triggered)
        {
            _pickUpsObjects.Rotate_L(15);
        }
        //Rotate Object R
        if (playerInputs.PlayerInputs.RotationObject_R.triggered)
        {
            _pickUpsObjects.Rotate_R(15);
        }

        playerInputs.PlayerInputs.Attack.performed += ctx => _player.MeleAtack();

    }

    public void GetInputValueToCamera()
    {
        Vector2 axisCamera = playerInputs.PlayerInputs.MovementCamera.ReadValue<Vector2>();
        print(axisCamera);
        _freeLookCamera.m_XAxis.Value = axisCamera.x;
        _freeLookCamera.m_YAxis.Value = axisCamera.y;
    }
    private void GetInput()
    {
        CinemachineCore.GetInputAxis = GetAxisCustom;
    }

    public float GetAxisCustom(string axisName)
    {
        // LookCamera.Normalize();

        if (axisName == "Mouse X")
        {
            if (LookCamera.x > deadZoneX || LookCamera.x < -deadZoneX) // To stabilise Cam and prevent it from rotating when LookCamera.x value is between deadZoneX and - deadZoneX
            {
                return LookCamera.x;
            }
        }

        else if (axisName == "Mouse Y")
        {
            return LookCamera.y;
        }

        return 0;
    }

    public Vector2 Vector2Movement()
    {
        Vector2 movement = playerInputs.PlayerInputs.Movement.ReadValue<Vector2>();
        return movement;
    }
    
    private void OnEnable()
    {
        playerInputs.Enable();
    }
    private void OnDisable()
    {
        playerInputs.Disable();
    }



}
