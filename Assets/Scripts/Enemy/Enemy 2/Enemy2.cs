using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : Enemy
{
    [SerializeField] GameObject _rockPrefab;
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
        //Instanciar rocas
    }
    private void Update()
    {
        anim.SetBool("isInFov", isInFov);
    }
    void InvokeRock()
    {

    }

}
