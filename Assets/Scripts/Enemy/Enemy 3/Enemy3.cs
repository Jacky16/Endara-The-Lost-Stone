using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy3 : Enemy
{
    [SerializeField]GameObject rayoPrefab;
    float counter;
    [SerializeField] float timeToShoot;
    public override void NearAttackPlayer()
    {
        
        print("Atacando de cerca");
    }
    public override void FarAttackPlayer()
    {
        navMeshAgent.speed = 0;
        navMeshAgent.SetDestination(Vector3.zero);
        Vector3 rotationDirection = (player.position - transform.position).normalized;
        Quaternion rotationToPlayer = Quaternion.LookRotation(rotationDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotationToPlayer, 3f * Time.deltaTime);

        anim.SetTrigger("farAttack");

    }

    public void Dead()
    {
        //Dead
    }

    public void LanzarRayo()
    {
        Instantiate(rayoPrefab, player.position, Quaternion.identity);
    }
    
    IEnumerator DelayMovement()
    {
        canPath = false;
        yield return new WaitForSeconds(1f);
        canPath = true;
    }
}
