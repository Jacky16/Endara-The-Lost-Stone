using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : Enemy
{
    [Header("Propiedades Roca")]
    [SerializeField] GameObject _rockPrefab;
    GameObject _rockThrowed;
    [SerializeField] Transform _transformRockPrefab;
    [SerializeField] Vector3 offsetRock = new Vector3(0, 0.09f, 0);
    float counter;
    [SerializeField] float _timeToShoot;
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

   
    void ThrowRock()
    {
        RockEnemy2 rockEnemy2 = _rockThrowed.GetComponent<RockEnemy2>();
        Rigidbody rb = _rockThrowed.GetComponent<Rigidbody>();

        _rockThrowed.transform.SetParent(null);
        rb.useGravity = true;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        Vector3 dir = player.position - transform.position;
        rockEnemy2.ShootRock(dir.normalized + offsetRock, true);
    }
    void InvokeRock()
    {
       _rockThrowed = Instantiate(_rockPrefab, _transformRockPrefab.position, Quaternion.identity,transform) as GameObject;
       
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
       
        
    }

}
