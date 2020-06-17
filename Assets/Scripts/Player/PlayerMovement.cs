using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Diagnostics;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    //Componentes
    [Header("Components")]
    [HideInInspector]
    public Animator anim;

    CharacterController characterController;

    [SerializeField]
    [Header("Animator Canvas Dead")]
    Animator animDead;

    Camera mainCam;

    [SerializeField]
    CoinManager _coinManager;

    PlayerSoundMovement playerSoundMovement;
    PlayerLifeManager playerLifeManager;
    GodManager godManager;
    public Transform initialPosition;

    [SerializeField]
    CapsuleCollider attackCollider;

    [Header("Velocidad y aceleración")]
    public float speedMax;
    public float acceleration = 20f;
    private float currentSpeed = 0f;

    //Vectores
    private Vector3 playerInput;
    private Vector3 movePlayer;
    private Vector3 camForward;
    private Vector3 camRight;

    [Header("Gravedad y salto")]
    [SerializeField]
    float gravity;

    [SerializeField]
    float jumpForce;

    float fallvelocity;

    [Header("Fuerza de empuje")]
    [SerializeField]
    float pushPower = 2f;

    //Donde se almacena la posicion del checkpoint
    Transform respawnCheckpoint;

    [Header("Particulas")]
    [SerializeField]
    GameObject _prefabParticleCoin;
    [SerializeField]
    ParticleSystem particleSystem_Jump;
    
    //Variables booleanas
    public static bool canMove = true;
    [HideInInspector] public static bool isModeGod;
    float unitsGod;
    bool isInMovingPlattform;
    bool playerIn2D;
    bool _activeAttackCollider;

    //Double Jump
    float coolDown;
    float timetoJump = 0.2f;
    bool doubleJump = true;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        playerLifeManager = GetComponent<PlayerLifeManager>();
        playerSoundMovement = GetComponent<PlayerSoundMovement>();
        mainCam = Camera.main;
    }
    private void Start()
    {
        attackCollider.enabled = false;
        _activeAttackCollider = false;
        speedMax = 10;
        acceleration = 40;
        gravity = 20;
        jumpForce = 9.5f;

        //godManager = GameObject.Find("Mode God Manager").GetComponent<GodManager>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        movePlayer.y = 0;
    }
    
    void Update()
    {
        if (canMove)
        {
            Movimiento();
        }
        else
        {
            anim.SetFloat("PlayerWalkVelocity", 0);
        }
    }
    void Movimiento()
    {
        //Obtener los inputs del Input Manager
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        //Calcular la direccion del player respecto a la camara
        CamDirection();
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;

        if (playerInput.sqrMagnitude > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movePlayer), .5f);
        }

        //Aceleracion
        if (playerInput.magnitude > 0.1f)
        {
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, speedMax);
        }
        else
        {
            currentSpeed -= acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, speedMax);
        }
        anim.SetFloat("PlayerWalkVelocity", currentSpeed);
        movePlayer *= currentSpeed;

        //Si estas en 2.5D, el eje Z se desactiva
        if (playerIn2D)
        {
            movePlayer.z = 0;
        }
        SetGravity();
        JumpPlayer();

        //Asignar movimiento al Character Controller
        characterController.Move(movePlayer * Time.deltaTime);

    }
    public void SetGravity()
    {
        anim.SetBool("isGrounded", characterController.isGrounded);
        if (characterController.isGrounded)
        {
            fallvelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallvelocity;
        }
        else
        {
            fallvelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallvelocity;
        }
        anim.SetFloat("PlayerVerticalVelocity", fallvelocity);


    }
    void ModeGod()
    {
        unitsGod = godManager.UnitsToJumpInModeGod();
        if (isModeGod)
        {
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
    public void SetPlayer2D(bool b)
    {
        playerIn2D = b;
    }
    void JumpPlayer()
    {
        coolDown += Time.deltaTime;
        if (InputManager.playerInputs.PlayerInputs.Jump.triggered && coolDown >= timetoJump)
        {
            if (!doubleJump)
            {
                return;
            }

            if (!characterController.isGrounded && !isInMovingPlattform)
            {
                 doubleJump = false;
            }

            fallvelocity = jumpForce;
            print(jumpForce);
            movePlayer.y = fallvelocity;
            anim.SetTrigger("PlayerJump");
            coolDown = 0;
            playerSoundMovement.PlaySoundJump();
            ParticlesJump(); //Particulas al saltar
        }

        if (!doubleJump && (characterController.isGrounded || isInMovingPlattform))
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
        if (playerLifeManager.AttempsPlayer() <= 0)
        {
            gameObject.tag = "Untagged";
            anim.SetTrigger("Dead");
            canMove = false;
        }
    }
    public void RespawnToWaypoint()
    {
        if (respawnCheckpoint != null)
        {
            transform.position = respawnCheckpoint.position;
        }
        else
        {
            transform.position = initialPosition.position;
        }
        return;
    }
    public void MeleAtack()
    {
        anim.SetTrigger("Attack");
    }
    public void ActiveColliderAttack()
    {
        attackCollider.enabled = true;
    }
    public void DisableColliderAttack()
    {
        attackCollider.enabled = false;
    }
    public void SetRespawn(Transform t)
    {
        respawnCheckpoint = t;
    }
    public void SetMovingPlattform(bool b)
    {
        isInMovingPlattform = b;
        print(isInMovingPlattform);
    }
   
    void ParticlesJump()
    {
        particleSystem_Jump.Play();
    }
    IEnumerator DeadCanvasAnimation() // Cuando te quedas sin vida, se ejecuta en un evento de la animacion de muerte
    {
        if (playerLifeManager.AttempsPlayer() <= 0)
        {
            animDead.SetTrigger("StartDead");
            yield return new WaitForSeconds(1f);
            RespawnToWaypoint();
            yield return new WaitForSeconds(1f);
            animDead.SetTrigger("EndDead");
            playerLifeManager.SetLifeToMax();
            gameObject.tag = "Player";
            canMove = true;
        }
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Cubo"))
        {
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
   
    public void Axis(float h, float v)
    {
        playerInput.x = h;
        playerInput.z = v;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Final")
        {
            SceneManager.LoadScene("VictoryScreen");
        }

        if (other.CompareTag("Coin"))
        {
            Instantiate(_prefabParticleCoin, other.transform.position, Quaternion.identity);
            _coinManager.SumCoins();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Muerte_Vacio"))
        {

        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Coin"))
        {
            Instantiate(_prefabParticleCoin, other.transform.position, Quaternion.identity);
            _coinManager.SumCoins();
            Destroy(other.gameObject);
        }
    }
    public void SetPlayerCanMove()
    {
        canMove =! canMove;
    }
    public bool PlayerIn2D()
    {
        return playerIn2D;
    }
    public static bool IsModeGod()
    {
        return isModeGod;
    }

}