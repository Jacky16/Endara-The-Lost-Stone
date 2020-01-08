using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_1 : Enemy
{
    [SerializeField] GameObject explosionPrefab;
    float explosionRand;
    float damageExplosion = 14;
    private void Start()
    {
        explosionRand = 1;
    }
    public override void AttackPlayer()
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
        GameObject g = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        g.GetComponent<ExplosionEnemy1>().GetDamage(DamageExplosion());

        Destroy(this.gameObject, 0.1f);
    }
    public float DamageExplosion()
    {
        return damageExplosion/3.0f;
    }
   
}