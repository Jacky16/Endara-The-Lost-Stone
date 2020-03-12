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
        navMeshAgent.speed = 0;
        Vector3 rotationDirection = (player.position - transform.position).normalized;
        Quaternion rotationToPlayer = Quaternion.LookRotation(rotationDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotationToPlayer, 1 * Time.deltaTime);
        if (!isInFov)
        {
            EnemyStates = States.FollowPath;
        }
        counter = counter + Time.deltaTime;
        //Instanciar Rayos
        if (counter > timeToShoot)
        {
            LanzarRayo();
            counter = 0;
        }

       // StartCoroutine(CoroutineLanzarRayo());
    }
    public override void FarAttackPlayer()
    {

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
   
    IEnumerator CoroutineLanzarRayo()
    {
        LanzarRayo();
        yield return new WaitForSeconds(1);
    }
  

}
