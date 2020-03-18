using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : Enemy
{
    [Header("Propiedades Roca")]
    [SerializeField] GameObject _rockPrefab;
    GameObject _currentRockPrefab;
    [SerializeField] Transform _transformRockPrefab;
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
        _currentRockPrefab.transform.SetParent(null);
        Speed speed = _currentRockPrefab.GetComponent<Speed>();
        Vector3 dir = player.position - transform.position;
        speed.ShootRock(dir.normalized, true);
    }
    void InvokeRock()
    {
       _currentRockPrefab = Instantiate(_rockPrefab, _transformRockPrefab.position, Quaternion.identity,transform) as GameObject;
       
    }
    public void CheckRock()
    {
        if (_currentRockPrefab)
        {
            Rigidbody rb = _currentRockPrefab.GetComponent<Rigidbody>();
            Vector3 velocityRock = rb.velocity;
            if (velocityRock == Vector3.zero)
            {
                Destroy(_currentRockPrefab);

            }
        }
       
        
    }

}
