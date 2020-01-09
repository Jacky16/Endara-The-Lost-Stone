using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2 : Enemy
{
    [SerializeField] GameObject rockPrefab;
    float counter;
    [SerializeField] float timeToShoot;
    public override void AttackPlayer()
    {
        navMeshAgent.speed = 0;
        Vector3 rotationDirection = (player.position - transform.position).normalized;
        Quaternion rotationToPlayer = Quaternion.LookRotation(rotationDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation,rotationToPlayer, 1 * Time.deltaTime);
        if (!isInFov)
        {
            EnemyStates = States.FollowPath;
        }
        //Instanciar rocas
    }
}
