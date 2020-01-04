using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
public class InputManager : MonoBehaviour
{
    public PlayerMovement player;
    [SerializeField]PickUpObjects pickUpsObjects;
    public PlayerGamepadInputs playerInputs;
    [SerializeField] CinemachineFreeLook playerCameraFreeLook;
    //Variables bools para los controles de movimiento
    bool isJostickLeftPressed;
    bool isJostickRightPressed;
    bool isWASDIsPressed;
    //Variables bool para los controles de interaccion
    bool canJump;
    bool isMouseRightClickPressed;
    bool isButtonGampedadAimPressed;
    Vector2 vector2Axis;
    [SerializeField] bool useGamepad;
    private void Awake()
    {
        playerInputs = new PlayerGamepadInputs();
    }
    private void Update() {
        ReadValuesGamePad();
        CheckButtonArePressed();
        ChangeAxisCamera();
        if (isJostickLeftPressed || isJostickRightPressed)
        {
            Debug.Log("Estoy tocando el mando...");
            useGamepad = true;

        }else if(Input.anyKey)
        {
            useGamepad = false;
        }
        else
        {
            useGamepad = true;
        }

        //Enviar info al player
        player.Axis(H(),V());

        MeleAttack();

    }

    void MeleAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            player.MeleAtack();
        }
    }
    void ReadValuesGamePad()
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

    
    void CheckButtonArePressed()
    {
        //Comprobacion de pulsacion de los josticks IZQUIERDOS
        playerInputs.Player_GamepadXbox.Movement.performed += x => JostickLeftTrue();
        playerInputs.Player_GamepadXbox.Movement.canceled += x => JostickLeftFalse();

        //Comprobacion de pulsacion de los josticks DERECHOS (para la camara)
        playerInputs.Player_GamepadXbox.CameraMovement.performed += x => JostickRightTrue();
        playerInputs.Player_GamepadXbox.CameraMovement.canceled += x => JostickRightFalse();

        //Comprobar si se estan usando las teclas WASD
        playerInputs.Player_Keyboard.Movement.performed += x => WASDTrue();
        playerInputs.Player_Keyboard.Movement.canceled += x => WASDFalse();

        //Comprobacion de pulsacion del boton de cojer en el Gamepad(X) y con el teclado(F)
       
        if (playerInputs.Player_Keyboard.CatchObject.triggered || playerInputs.Player_GamepadXbox.CatchObject.triggered)
        {
            pickUpsObjects.PillarElObjeto();
        }
        if (playerInputs.Player_Keyboard.TrowObject.triggered || playerInputs.Player_GamepadXbox.ThrowObject.triggered)
        {
            pickUpsObjects.ThrowObject();
        }

        //Comprobación de boton de saltar en el Gamepad(A)
        playerInputs.Player_GamepadXbox.Jump.performed += x => ButtonJumpTrue();
        playerInputs.Player_GamepadXbox.Jump.canceled += x => ButtonJumpFalse();

        //Comprobacion del boton de apuntar en el raton(Click Derecho)
        playerInputs.Player_Keyboard.Aim.performed += x => RightClickMouseTrue();
        playerInputs.Player_Keyboard.Aim.canceled += x => RightClickMouseFalse();
        //Debug.Log(IsRightClickMousePressed());
        //Comprobacion del boton de apuntar en el Gamepad(LT/R2)
       // playerInputs.playe

    }



    void ChangeAxisCamera()
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
    //Metodos bool para comprobar si se esta tocando las teclas de movimiento
    void WASDTrue()
    {
        isWASDIsPressed = true;
    }
    void WASDFalse()
    {
        isWASDIsPressed = false;
    }

    //Metodos bool para comprobar el JostickLeft si es presionado
    void JostickLeftTrue()
    {
        isJostickLeftPressed = true;
    } 
    void JostickLeftFalse()
    {
        isJostickLeftPressed = false;
    }
    void RightClickMouseTrue()
    {
        isMouseRightClickPressed = true;
    }
    void RightClickMouseFalse()
    {
        isMouseRightClickPressed = false;
    }
    
    
    //Metodos bool para comprobar el JostickLeft si es presionado
    void JostickRightTrue()
    {
        isJostickRightPressed = true;
    }
    void JostickRightFalse()
    {
        isJostickRightPressed = false;
    }
    //Metodos bool para comprobar el boton de salto
    void ButtonJumpTrue()
    {
        canJump = true;
    }
    void ButtonJumpFalse()
    {
        canJump = false;
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
    public bool CanJump()
    {
        return canJump;
    }
    public bool IsRightClickMousePressed()
    {
        return isMouseRightClickPressed;
    }
    public bool IsAimButtonGamepadPressed()
    {
        return isButtonGampedadAimPressed;
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
