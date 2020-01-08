using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_1 : Enemy
{
   
    public void AttackPlayer()
    {
        if (explosionRand == 0)
        {
            navMeshAgent.SetDestination(player.position);
        }
        else if (explosionRand == 1)
        {
            navMeshAgent.SetDestination(player.position);
            if (Vector3.Distance(transform.position, player.position) < radiusAttack)
            {
                navMeshAgent.speed = 0;
                anim.SetTrigger("Explosion");

            }
        }
    }
    public void Explosion()
    {
        gameObject.SetActive(false);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject, 0.1f);
    }
   
}