using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Componentes")]
    public Rigidbody rb;
    public InputManager inputManager;
    public CharacterController player;
    public Animator anim;
    public Camera mainCam;
    [SerializeField] PlayerLifeManager playerLifeManager;

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
    [SerializeField] float gravity = 9.8f;
    [SerializeField] float jumpForce;
    
    float fallvelocity;
    
    [Header("Fuerza de empuje")]
    public float pushPower = 2f;

 
    //maquinas de estados
    enum PlayerStates{idle,walking,jumping};
    PlayerStates playerStates;
    //variables booleanas
    bool canMove = false;

    


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();        
    }
    void Update()
    {
          Movimiento();
    }

    public void Movimiento(){


        anim.SetBool("IsGrounded", player.isGrounded);

        Axis(inputManager.H(),inputManager.V());
        playerInput = new Vector3(horizontal, 0, vertical);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        anim.SetFloat("PlayerWalkVelovity", playerInput.magnitude * speed);
        CamDirection();
        Vector3 rotationDirection = playerInput.x * camRight + playerInput.z * camForward;
        if (Input.anyKey)
        {
            transform.rotation = Quaternion.LookRotation(rotationDirection.normalized , Vector3.up);

        }

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        SetGravity();
        
        JumpPlayer();
               


        player.Move(movePlayer  * speed * Time.deltaTime);
 
    }
    public void SetGravity()
    {
        if (player.isGrounded )
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
    public void JumpPlayer()
    {
        Debug.Log(currentJump);
        if (player.isGrounded && maxJumps > currentJump && Input.GetButtonDown("Jump"))
        {
            Debug.Log(1);
            fallvelocity = jumpForce;
            movePlayer.y = fallvelocity;
            anim.SetTrigger("PlayerJump");
            currentJump = 2;
        }else if ((player.isGrounded || maxJumps == currentJump) && Input.GetButtonDown("Jump"))
        {
            Debug.Log(2);

            fallvelocity = jumpForce;
            movePlayer.y = fallvelocity;
            currentJump = 0;

        }
        else if(player.isGrounded)
        {
            currentJump = 0;
        }
    }
    public void CamDirection()
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
        Destroy(this.gameObject);
    }
        
    
    public void Axis(float h, float v){
        horizontal = h;
        vertical = v;
    }
    
    public void RestarVida(int cantidadARestar)
    {
        playerLifeManager.RestarLife(cantidadARestar);
    }
    
   
    

    

    
    private void OnControllerColliderHit(ControllerColliderHit hit)
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


    
    






}
