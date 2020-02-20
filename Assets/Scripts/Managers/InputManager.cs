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
    [SerializeField] CinemachineFreeLook playerCameraVirtual;
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
        MeleAttack();
        ReadValuesGamePad();
        CheckButtonArePressed();
        ChangeAxisCamera();
        if (isJostickLeftPressed || isJostickRightPressed)
        {
            Debug.Log("Estoy tocando el mando...");
            useGamepad = true;

        }else if(Input.anyKey || Input.GetAxis("Mouse Y") > 0.01f || Input.GetAxis("Mouse X") > 0.01f)
        {
            useGamepad = false;
        }
        else
        {
            useGamepad = true;
        }

        //Enviar info al player
        player.Axis(H(),V());

        //MeleAttack();

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
            vector2Axis = playerInputs.Player_GamepadXbox.LeftJostyck.ReadValue<Vector2>();
        }
        else
        {
            vector2Axis = playerInputs.Player_Keyboard.Movement.ReadValue<Vector2>();

        }
    }

    
    void CheckButtonArePressed()
    {
        //Comprobacion de pulsacion de los josticks IZQUIERDOS
        playerInputs.Player_GamepadXbox.LeftJostyck.performed += x => isJostickLeftPressed = true;
        playerInputs.Player_GamepadXbox.LeftJostyck.canceled += x => isJostickLeftPressed = false;

        //Comprobacion de pulsacion de los josticks DERECHOS (para la camara)
        playerInputs.Player_GamepadXbox.RightJostyck.performed += x => isJostickRightPressed = true;
        playerInputs.Player_GamepadXbox.RightJostyck.canceled += x => isJostickRightPressed = false;

        //Comprobar si se estan usando las teclas WASD
        playerInputs.Player_Keyboard.Movement.performed += x => isWASDIsPressed = true;
        playerInputs.Player_Keyboard.Movement.canceled += x => isWASDIsPressed = false;

        //Comprobacion de pulsacion del boton de cojer en el Gamepad(X) y con el teclado(F)
       
        if (playerInputs.Player_Keyboard.CatchObject.triggered || playerInputs.Player_GamepadXbox.X.triggered)
        {
            pickUpsObjects.PillarElObjeto();
        }
        if (playerInputs.Player_Keyboard.TrowObject.triggered || playerInputs.Player_GamepadXbox.RT.triggered)
        {
            pickUpsObjects.ThrowObject();
        }

        //Rotacion del objero pickeado
        if (playerInputs.Player_GamepadXbox.RE.triggered) //Girar a la derecha
        {
            pickUpsObjects.Rotate_R(15);

        }
        if (playerInputs.Player_GamepadXbox.LB.triggered) //Girar a la izquierda
        {
            pickUpsObjects.Rotate_L(15);

        }



        ////Comprobación de boton de saltar en el Gamepad(A)
        //playerInputs.Player_GamepadXbox.A.performed += x => ButtonJumpTrue();
        //playerInputs.Player_GamepadXbox.A.canceled += x => ButtonJumpFalse();

        //Comprobacion del boton de apuntar en el raton(Click Derecho)
        playerInputs.Player_Keyboard.Aim.performed += x => RightClickMouseTrue();
        playerInputs.Player_Keyboard.Aim.canceled += x => RightClickMouseFalse();
      

    }



    void ChangeAxisCamera()
    {
        if (useGamepad)
        {
            playerCameraVirtual.m_XAxis.m_InputAxisValue = playerInputs.Player_GamepadXbox.RightJostyck.ReadValue<Vector2>().x;
            playerCameraVirtual.m_YAxis.m_InputAxisValue = playerInputs.Player_GamepadXbox.RightJostyck.ReadValue<Vector2>().y;

            //Cambiar los nombres de los inputs a null
            playerCameraVirtual.m_XAxis.m_InputAxisName = null;
            playerCameraVirtual.m_YAxis.m_InputAxisName = null;
        }
        else
        {
            playerCameraVirtual.m_XAxis.m_InputAxisName = "Mouse X";
            playerCameraVirtual.m_YAxis.m_InputAxisName = "Mouse Y";
        }
    }
   

   
   
    void RightClickMouseTrue()
    {
        isMouseRightClickPressed = true;
    }
    void RightClickMouseFalse()
    {
        isMouseRightClickPressed = false;
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
