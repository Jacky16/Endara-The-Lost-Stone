using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using DG.Tweening;
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]InputManager inputManager;
    CharacterController player;
    Animator anim;
    [SerializeField] Camera mainCam;
    PlayerLifeManager playerLifeManager;
    GodManager godManager;
    public Transform initialPosition;
    [SerializeField] CapsuleCollider attackCollider;
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
    [SerializeField] Transform respawnPosition;
    float unitsGod;


    //Variables booleanas
    public static bool canMove = true;
    public bool isGod;
    [SerializeField] bool isInitialPosition;
    private bool doubleJump = true;

    private void Start()
    {
        attackCollider.enabled = false;
        player = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        playerLifeManager = GetComponent<PlayerLifeManager>();
        //godManager = GameObject.Find("Mode God Manager").GetComponent<GodManager>();

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
        if (canMove)
        {
            Movimiento();

        }
    }
    public void Movimiento(){
        anim.SetBool("isGrounded", player.isGrounded);
        
        playerInput = new Vector3(inputManager.Vector2Movement().x, 0, inputManager.Vector2Movement().y);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        anim.SetFloat("PlayerWalkVelocity", playerInput.magnitude * speed);

        CamDirection();
        Vector3 rotationDirection = playerInput.x * camRight + playerInput.z * camForward;
        Vector3 currentRotation = rotationDirection;
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        if (movePlayer != Vector3.zero )
        {
            transform.LookAt(transform.position + movePlayer);

        }
        //transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(currentRotation), 1);
        SetGravity();    
        JumpPlayer();
        if (PickUpObjects.IsCatchedObject())
        {
            player.Move(movePlayer * (speed / PickUpObjects.MassObjectPicked() * Time.deltaTime));
        }
        else
        {
            player.Move(movePlayer * (speed * Time.deltaTime));
        }
    } 
    public void SetGravity()
    {
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
    public void JumpPlayer()
    {
        if (InputManager.playerInputs.PlayerInputs.Jump.triggered)
        {

            if (!doubleJump)
            {
                return;

            }

            if (!player.isGrounded)
            {
                doubleJump = false;

            }
            Debug.Log("He saltado");
            if (PickUpObjects.IsCatchedObject())
            {
                float myJumpForce = jumpForce / PickUpObjects.MassObjectPicked();
                fallvelocity = myJumpForce;
                print(myJumpForce);
            }
            if(!PickUpObjects.IsCatchedObject())
            {
                fallvelocity = jumpForce;
                print(jumpForce);
            }
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
        if (respawnPosition != null)
        {
            transform.position = respawnPosition.position;
        }
        else
        {
            transform.position = initialPosition.position;
           
        }
    }
    public void Axis(float h,float v){
        playerInput.x = h;
        playerInput.z = v;
    }
    public void MeleAtack()
    {
        transform.DOLocalRotate(new Vector3(0, 360, 0), .5f,RotateMode.LocalAxisAdd).OnComplete(() => attackCollider.enabled = false);
        attackCollider.enabled = true;
    }
    public void SetRespawn(Transform t)
    {
        respawnPosition = t;
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
        if(hit.collider.gameObject.name != "Baldosa")
        {
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
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Final")
        {
            SceneManager.LoadScene("VictoryScreen");
        }
        if (other.CompareTag("Muerte"))
        {
            PlayerDead();
        }
        
    }
    

}
