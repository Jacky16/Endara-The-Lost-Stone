using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy3 : Enemy
{
    [SerializeField]GameObject rayoPrefab;
    [SerializeField] GameObject PrefabParticlesNearAttack;
    float counter;
    [SerializeField] float timeToShoot;
    public LayerMask layerMaskRay;
    [SerializeField] Transform positionParticlesNearAttack;
    [SerializeField] float timeToAttack = .2f;
    public override void NearAttackPlayer()
    {
        navMeshAgent.speed = 0;
        navMeshAgent.SetDestination(Vector3.zero);
        Vector3 rotationDirection = (player.position - transform.position).normalized;
        Quaternion rotationToPlayer = Quaternion.LookRotation(rotationDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotationToPlayer, 3f * Time.deltaTime);
        if (counter >= timeToAttack)
        {
            anim.SetTrigger("nearAttack");
            counter = 0;
        }
        counter += Time.deltaTime;

    }
    public override void FarAttackPlayer()
    {
        navMeshAgent.speed = 0;
        navMeshAgent.SetDestination(Vector3.zero);
        Vector3 rotationDirection = (player.position - transform.position).normalized;
        Quaternion rotationToPlayer = Quaternion.LookRotation(rotationDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotationToPlayer, 3f * Time.deltaTime);
        if(counter >= timeToAttack)
        {
            anim.SetTrigger("farAttack");
            counter = 0;
        }
        counter += Time.deltaTime;
    }
    public void Pisoton()
    {
        GameObject g = PrefabParticlesNearAttack;
        Instantiate(g, positionParticlesNearAttack.position, Quaternion.identity);
        Destroy(g, 5);
    }
    public void LanzarRayo()
    {
       
        if (isInFarAttack)
        {
            RaycastHit hit;
            Ray ray;
            if (Physics.Raycast(player.position, transform.TransformDirection(Vector3.down), out hit, 10, layerMaskRay))
            {
                GameObject g = Instantiate(rayoPrefab, hit.point, Quaternion.identity);
                Destroy(g, 6);
            }
        }

    }
    
    IEnumerator DelayMovement()
    {
        canPath = false;
        yield return new WaitForSeconds(1f);
        canPath = true;
    }
}
