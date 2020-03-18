using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
public class  InputManager : MonoBehaviour
{
    [SerializeField] PlayerMovement _player;
    [SerializeField] PickUpObjects _pickUpsObjects;
    [Header("Camara Player")]
    [SerializeField] CinemachineFreeLook _freeLookCamera;

    public static InputsPlayer playerInputs;
    public PlayerInput playerInput;

    private Vector2 LookCamera; // your LookDelta
    public float deadZoneX = 0.2f;
    public static bool useGamepad;
    public enum ControlsState { PS4,Xbox,KeyBoard};
    public static ControlsState controlsState;
    bool isRotating_L = false;
    bool isRotating_R = false;

    private void Awake()
    {
        playerInputs = new InputsPlayer();
        playerInput = GetComponent<PlayerInput>();
       
        //Control de la camara
        playerInputs.PlayerInputs.MovementCamera.performed += ctx => LookCamera = ctx.ReadValue<Vector2>().normalized;
        playerInputs.PlayerInputs.MovementCamera.performed += ctx => GetInput();
        playerInputs.PlayerInputs.MovementCamera.canceled += ctx => LookCamera = Vector3.zero;

    }
    private void Update()
    {
        #region Comprobacion: Rotacion de objetos
        
        if (isRotating_L)
        {
            _pickUpsObjects.Rotate_L(5);
        } 
        if (isRotating_R)
        {
            _pickUpsObjects.Rotate_R(5);
        }
        #endregion
    }
    public void Rotate_L(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            isRotating_L = true;
        }
        else
        {
            isRotating_L = false;
        }   
    }
    public void Rotate_R(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            isRotating_R = true;
        }
        else
        {
            isRotating_R = false;
        }
    }
    public void Attack(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _player.MeleAtack();
        }
    }
    public void SwitchInputs()
    {
        switch (playerInput.currentControlScheme)
        {
            case "PS4":
                controlsState = ControlsState.PS4;
                print("PS4");
                break;
            case "Xbox":
                controlsState = ControlsState.Xbox;
                print("Xbox");
                break;
            case "KeyboardMouse":
                print("KeyboardMouse");
                controlsState = ControlsState.KeyBoard;
                break;
        }
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
