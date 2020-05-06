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
    //Componentes
    [Header("Components")]
    [HideInInspector]
    public Animator anim;

    CharacterController characterController;

    [SerializeField]
    Animator animDead;

    [SerializeField]
    Camera mainCam;

    [SerializeField]
    CoinManager _coinManager;

    PlayerSoundMovement playerSoundMovement;
    PlayerLifeManager playerLifeManager;
    GodManager godManager;
    public Transform initialPosition;

    [SerializeField]
    CapsuleCollider attackCollider;

    [Header("Velocidad")]
    public float speedMax;
    public float acceleration = 20f;
    private float currentSpeed = 0f;

    [Header("Controles")]
    private Vector3 playerInput;
    private Vector3 movePlayer;
    private Vector3 camForward;
    private Vector3 camRight;

    [Header("Gravedad")]
    [SerializeField]
    float gravity;

    [SerializeField]
    float jumpForce;

    float fallvelocity;

    [Header("Fuerza de empuje")]
    public float pushPower = 2f;

    [Header("Respawn Position")]
    [SerializeField]
    Transform respawnCheckpoint;

    [Header("Particle Coin")]
    [SerializeField]
    GameObject _prefabParticleCoin;

    float unitsGod;

    //Variables booleanas
    public static bool canMove = true;
    public bool isGod;
    [SerializeField]
    bool isInitialPosition;

    public bool doubleJump = true;

    [SerializeField]
    bool isInMovingPlattform;

    public bool playerIn2D;
    bool _activeAttackCollider;

    //Doubble Jump
    float coolDown;
    float timetoJump = 0.2f;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        playerLifeManager = GetComponent<PlayerLifeManager>();
        playerSoundMovement = GetComponent<PlayerSoundMovement>();
    }
    private void Start()
    {
        attackCollider.enabled = false;
        _activeAttackCollider = false;

        //godManager = GameObject.Find("Mode God Manager").GetComponent<GodManager>();
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        movePlayer.y = 0;
    }
    void FixedUpdate()
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
    public void Movimiento()
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
    public void ColliderAttack()
    {
        _activeAttackCollider = !_activeAttackCollider;
        attackCollider.enabled = _activeAttackCollider;
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
        }
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
            if (rb.velocity.magnitude <= 0.499f)
            {
                anim.SetBool("isPushing", false);
            }
            if (rb.velocity.magnitude > 0)
            {
                anim.SetBool("isPushing", true);
            }
            print(rb.velocity.magnitude);

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

}