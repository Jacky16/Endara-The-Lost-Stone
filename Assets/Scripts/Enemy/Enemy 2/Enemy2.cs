using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : Enemy
{
    [Header("Propiedades Roca")]

    [SerializeField] 
    GameObject _rockPrefab;

    [HideInInspector]public GameObject _rockThrowed;

    [SerializeField] 
    Transform _transformRockPrefab;

    public Vector3 offsetRock = new Vector3(0, 0.09f, 0);

    [SerializeField]
    GameObject gameObjectNearAttack;
    bool activateNearAttack = false;

    [Header("Audio")]
    [SerializeField]
    AudioClip audioInvokeRock;
    [SerializeField]
    AudioClip audioNearAttack;
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public override void NearAttackPlayer()
    {
        anim.SetTrigger("nearAttack");
    }
    public override void FarAttackPlayer()
    {
        anim.SetTrigger("farAttack");
        navMeshAgent.speed = 0;
        navMeshAgent.SetDestination(Vector3.zero);
        Vector3 rotationDirection = (player.position - transform.position).normalized;
        Quaternion rotationToPlayer = Quaternion.LookRotation(rotationDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotationToPlayer, 1.5f * Time.deltaTime);
        if (!isInFov)
        {
            EnemyStates = States.FollowPath;
        }

    }

    public void NearAttack() //Se ejecuta en la animacion 
    {
        activateNearAttack = !activateNearAttack;
        gameObjectNearAttack.SetActive(activateNearAttack);
        
    }
    public void PlaySoundNearAttack()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioNearAttack);
        }
    }

    void InvokeRock()// Se ejecuta en un evento en la animacion de Invocar la roca
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioInvokeRock);
        }
        
        _rockThrowed = Instantiate(_rockPrefab, _transformRockPrefab.position, Quaternion.identity, transform) as GameObject;

    }
    void ThrowRock()// Se ejecuta en un evento en la animacion de lanzar la roca
    {
        RockEnemy2 rockEnemy2 = _rockThrowed.GetComponent<RockEnemy2>();
        Rigidbody rb = _rockThrowed.GetComponent<Rigidbody>();

        _rockThrowed.transform.SetParent(null);
        rb.useGravity = true;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        Vector3 dir = player.position - transform.position;
        //rockEnemy2.ShootRock(dir.normalized + offsetRock, true);
    }
   
    public void CheckRock()
    {
        if (_rockThrowed)
        {
            Rigidbody rb = _rockThrowed.GetComponent<Rigidbody>();
            Vector3 velocityRock = rb.velocity;
            if (velocityRock == Vector3.zero)
            {
                Destroy(_rockThrowed);
            }
        }
    } // Se ejecuta al principio de cada animacion (en eventos) que no sea de lanzar las rocas

    public Vector3 PlayerPosition()
    {
        return player.position;
    }
}