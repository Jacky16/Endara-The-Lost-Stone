using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
//[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    InputManager inputManager;
    CharacterController player;
    Animator anim;
    public Camera mainCam;
    PlayerLifeManager playerLifeManager;
    GodManager godManager;
    public Transform initialPosition;

    [Header("Velocidad")]
    public float speed = 6.5F;
  
    [Header("Controles")]
    //[Range(0,1000)][SerializeField] float speedAceleration;
    private Vector3 playerInput;
    private Vector3 movePlayer;
    private Vector3 camForward;
    private Vector3 camRight;
    private float horizontal;
    private float vertical;
    private int maxJumps = 2;
    private int currentJump = 0;
 
  
    [Header("Gravedad")]
    [SerializeField] float gravity;
    [SerializeField] float jumpForce;
    
    float fallvelocity;
    
    [Header("Fuerza de empuje")]
    public float pushPower = 2f;

    float unitsGod;
 
    //Maquinas de estados
    enum PlayerStates{idle,walking,jumping};
    PlayerStates playerStates;

    //Variables booleanas
    bool canMove = false;
    public bool isGod;
    [SerializeField] bool isInitialPosition;
    private bool doubleJump = true;


    private void Start()
    {
        player = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        inputManager = GameObject.Find("Input Manager").GetComponent<InputManager>();
        playerLifeManager = GameObject.Find("Player Life Manager").GetComponent<PlayerLifeManager>();
        godManager = GameObject.Find("Mode God Manager").GetComponent<GodManager>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        movePlayer.y = 0;
        if (isInitialPosition)
        {
            transform.position = initialPosition.position;
        }
        else
        {
            return;
        }
    }
    void Update()
    {
        Movimiento();
        AimingManager();
    }
    public void Movimiento(){
        print(player.isGrounded);
        //print(movePlayer.y);
        anim.SetBool("isGrounded", player.isGrounded);
        Axis(inputManager.H(),inputManager.V());
        playerInput = new Vector3(horizontal, 0, vertical);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        anim.SetFloat("PlayerWalkVelocity", playerInput.magnitude * speed);

        CamDirection();
        Vector3 rotationDirection = playerInput.x * camRight + playerInput.z * camForward;
        if (inputManager.IsJostickLeftPressed() || inputManager.IsWASDIsPressed())
        {
            Vector3 currentRotation = rotationDirection.normalized;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentRotation),1);
        }
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        SetGravity(); 
        JumpPlayer();
        player.Move(movePlayer  * (speed * Time.deltaTime));
    }
    void AimingManager()
    {
        anim.SetBool("Aiming", inputManager.IsRightClickMousePressed());
        
    }
    public void SetGravity()
    {
        //Debug.Log("Fall velocity is: " + player.velocity.y);

        if (isGod)
        {
            ModeGod();
        }
        else
        {
            anim.SetBool("isGrounded", player.isGrounded);

            if (player.isGrounded)
            {
                fallvelocity = -gravity * Time.deltaTime;
                movePlayer.y = fallvelocity;
            }
            else
            {
                fallvelocity -= gravity * Time.deltaTime;
                movePlayer.y = fallvelocity;
                anim.SetFloat("PlayerVerticalVelocity", player.velocity.y);
            }

        }
    }
    void ModeGod()
    {

        unitsGod = godManager.UnitsToJumpInModeGod();
        if (isGod)
        {
            Debug.Log("Es Dios");
            if (Input.GetKey(KeyCode.Space))
            {
                movePlayer.y += unitsGod;
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                movePlayer.y -= unitsGod;

            }
            
            playerLifeManager.enabled = false;
        }
    }
    void JumpPlayer()
    {

        if (inputManager.playerInputs.Player_GamepadXbox.Jump.triggered || inputManager.playerInputs.Player_Keyboard.Jump.triggered)
        {
            if (!doubleJump)
            {
                return;

            }

            if (!player.isGrounded)
            {
                doubleJump = false;

            }

            fallvelocity = jumpForce;
            movePlayer.y = fallvelocity;
            anim.SetTrigger("PlayerJump");
        }

        if (!doubleJump && player.isGrounded)
        {
            doubleJump = true;
        }

    }
    void CamDirection()
    {
        camForward = mainCam.transform.forward;
        camRight = mainCam.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
    public void PlayerDead()
    {
        //Destroy(this.gameObject);
        Cursor.visible = true;

        SceneManager.LoadScene("LostScreen");
        
    }
    public void Axis(float h, float v){
        horizontal = h;
        vertical = v;
    }
    public void MeleAtack()
    {
        anim.SetTrigger("Attack");
    }
    public void RestarVida(int cantidadARestar)
    {
        playerLifeManager.RestarLife(cantidadARestar);
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ////Salto entre plataformas
        //if (!player.isGrounded && hit.normal.y < 0.1f)
        //{
        //Debug.Log("He saltado en entre plataformas");

        //if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //    verticalVelocity = jumpForce;
        //    movePlayer = hit.normal * 1.5f;
        //    }
            
        //}
    float valueMass;
    Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb == null || rb.isKinematic)
        {
            return;
        }

        if (hit.moveDirection.y < -0.3f)
        {
            return;
        }

        valueMass = rb.mass;
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        rb.velocity = (pushDir * pushPower) / valueMass;
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Final")
        {
            SceneManager.LoadScene("VictoryScreen");
        }
    }

}
