using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
public class InputManager : MonoBehaviour
{
    public PlayerMovement player;
    //[SerializeField] PickUpObjects pickUpsObjects;
    PlayerGamepadInputs playerInputs;
    [SerializeField] CinemachineFreeLook playerCameraFreeLook;
    bool isJostickLeftPressed;
    bool isJostickRightPressed;
    bool isWASDIsPressed;
    Vector2 vector2Axis;
    [SerializeField] bool useGamepad;
    private void Awake()
    {
        playerInputs = new PlayerGamepadInputs();
    }
    private void Update() {
        ReadValuesGamePad();
        ReadCheckJosticks();
        
        ChangeAxisCamera();

        //Enviar info al player
        player.Axis(H(),V());
        MeleAttack();
        
    }
    public void MeleAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            player.MeleAtack();
        }
    }
    public void ReadValuesGamePad()
    {
        if (useGamepad)
        {
            vector2Axis = playerInputs.Player_GamepadXbox.Movement.ReadValue<Vector2>();
        }
        else
        {
            vector2Axis = playerInputs.Player_Keyboard.Movement.ReadValue<Vector2>();

        }
    }
        
    
    public void ReadCheckJosticks()
    {
        //Comprobacion de pulsacion de los josticks IZQUIERDOS
        playerInputs.Player_GamepadXbox.Movement.performed += x => JostickLeftTrue();
        playerInputs.Player_GamepadXbox.Movement.canceled += x => JostickLeftFalse();

        //Comprobacion de pulsacion de los josticks DERECHOS (para la camara)
        playerInputs.Player_GamepadXbox.CameraMovement.performed += x => JostickRightTrue();
        playerInputs.Player_GamepadXbox.CameraMovement.canceled += x => JostickRightFalse();
    }
    public void ReadCkeckWASD()
    {
        playerInputs.Player_Keyboard.Movement.performed += x => WASDTrue();
        playerInputs.Player_Keyboard.Movement.canceled += x => WASDFalse();

    }

    public void ChangeAxisCamera()
    {
        if (useGamepad)
        {
            playerCameraFreeLook.m_XAxis.m_InputAxisValue = playerInputs.Player_GamepadXbox.CameraMovement.ReadValue<Vector2>().x;
            playerCameraFreeLook.m_YAxis.m_InputAxisValue = playerInputs.Player_GamepadXbox.CameraMovement.ReadValue<Vector2>().y;

            //Cambiar los nombres de los inputs a null
            playerCameraFreeLook.m_XAxis.m_InputAxisName = null;
            playerCameraFreeLook.m_YAxis.m_InputAxisName = null;
        }
        else
        {
            playerCameraFreeLook.m_XAxis.m_InputAxisName = "Mouse X";
            playerCameraFreeLook.m_YAxis.m_InputAxisName = "Mouse Y";
        }
    }
    //Variables bool para comprobar si se esta tocando las teclas de movimiento
    public void WASDTrue()
    {
        isWASDIsPressed = true;
    }
    public void WASDFalse()
    {
        isWASDIsPressed = false;
    }
    //Variables bool para comprobar el JostickLeft si es presionado
    public void JostickLeftTrue()
    {
        isJostickLeftPressed = true;
    } 
    public void JostickLeftFalse()
    {
        isJostickLeftPressed = false;
    }
    //Variables bool para comprobar el JostickLeft si es presionado
    public void JostickRightTrue()
    {
        isJostickRightPressed = true;
    }
    public void JostickRightFalse()
    {
        isJostickRightPressed = false;
    }

    //Recogue los valores para los inputs
    public float H()
    {
        return vector2Axis.x;
    }
    public float V(){
        return vector2Axis.y;
    }
    public bool IsJostickLeftPressed()
    {
        return isJostickLeftPressed;
    }
    public bool IsJostickRightPressed()
    {
        return isJostickRightPressed;
    }
   
    public bool IsWASDIsPressed() 
    {
        return isWASDIsPressed;
    }
    //Logica para el input System
    public void OnEnable()
    {
        playerInputs.Enable();
    }
    public void OnDisable()
    {
        playerInputs.Disable();
    }

   


    
    
}
