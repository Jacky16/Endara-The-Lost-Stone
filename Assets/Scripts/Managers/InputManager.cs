using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
public class InputManager : MonoBehaviour
{
    [Header("Componentes Player")]
    [SerializeField] PlayerMovement _player;
    [SerializeField] PickUpObjects _pickUpsObjects;

    [Header("Camara Player")]
    public  CinemachineFreeLook _freeLookCamera;
    [Header("Componentes para los inputs")]
    public static InputsPlayer playerInputs;
    public PlayerInput playerInput;
    Vector2 _inputsValueCamera;
    public static Vector2 movement;
    public enum ControlsState { PS4, Xbox, KeyBoard };
    public static ControlsState controlsState;

    bool _isRotating_L = false;
    bool _isRotating_R = false;
    public float deadZoneX;
    private void Awake()
    {
        playerInputs = new InputsPlayer();
        playerInput = GetComponent<PlayerInput>();
    }
  
    private void Update()
    {
        movement = playerInputs.PlayerInputs.Movement.ReadValue<Vector2>();
        playerInputs.PlayerInputs.MovementCamera.canceled += ctx => _freeLookCamera.m_XAxis.m_InputAxisValue = 0;
        #region Comprobacion: Rotacion de objetos

        if (_isRotating_L)
        {
            _pickUpsObjects.Rotate_L(2.5f);
        }
        if (_isRotating_R)
        {
            _pickUpsObjects.Rotate_R(2.5f);
        }

    }
    public void Rotate_L(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            _isRotating_L = true;
        }
        else
        {
            _isRotating_L = false;
        }
    }
    public void Rotate_R(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            _isRotating_R = true;
        }
        else
        {
            _isRotating_R = false;
        }
    }
    #endregion

    public void Attack(InputAction.CallbackContext ctx)
    {
        if (ctx.started && !PickUpObjects.CanCatchObject())
        {
            _player.MeleAtack();
        }
    }
    public void CatchObject(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _pickUpsObjects.CatchObjectSystem();
        }
    }
    public void SwitchInputs()
    {
        print(playerInput.currentControlScheme);
        switch (playerInput.currentControlScheme)
        {
            case "PS4":
                controlsState = ControlsState.PS4;
                break;
            case "Xbox":
                controlsState = ControlsState.Xbox;
                break;
            case "KeyboardMouse":
                controlsState = ControlsState.KeyBoard;
                break;
        }
    }
    public void GetAxisCustom()
    {
        _inputsValueCamera = playerInputs.PlayerInputs.MovementCamera.ReadValue<Vector2>();
        //El valor de x se pone a zero para evitar que se mueva solo

        if (_inputsValueCamera.x > deadZoneX || _inputsValueCamera.x < -deadZoneX)
        {
            _freeLookCamera.m_XAxis.m_InputAxisValue = _inputsValueCamera.x;
        }
        _freeLookCamera.m_YAxis.m_InputAxisValue = _inputsValueCamera.y;
    }
    
    public static Vector2 Vector2Movement()
    {
        return movement;
    }
    private void OnEnable()
    {
        playerInputs.Enable();
        SwitchInputs();
    }
    private void OnDisable()
    {
        playerInputs.Disable();
    }
}