using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_1 : Enemy
{
    [SerializeField] GameObject explosionPrefab;
    float explosionRand;
    [SerializeField]float damageExplosion = 14;
    [SerializeField] GameObject attackZone;
    private void Start()
    {
        explosionRand = 0;
    }
    public override void AttackPlayer()
    {
        if (explosionRand == 0)
        {
            if (BetweenDistance < radiusAttack && isInFov)
            {
                navMeshAgent.SetDestination(player.position);
                Debug.Log("Estoy atacando al player");
            }

        }
        else if (explosionRand == 1)
        {
            if (BetweenDistance <= radiusAttack)
            {
                navMeshAgent.speed = 0;
                anim.SetTrigger("Explosion");
                print("He explotado");

            }
        }
    }

    public void Explosion()
    {
        GameObject g = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
        g.GetComponent<ExplosionEnemy1>().GetDamage(DamageExplosion());
        Debug.Log("He explotado");
        Destroy(this.gameObject, 0.1f);
    }
    public float DamageExplosion()
    {
        return damageExplosion/3.0f;
    }
    public float Damage()
    {
        return attackDamage;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            
            StartCoroutine(RestLifePlayer(other));
            anim.SetTrigger("Attack");

        }
    }
    IEnumerator RestLifePlayer(Collider other)
    {
        yield return new WaitForSeconds(1);
        other.GetComponent<PlayerLifeManager>().RestarLife(attackDamage /2); // Se divide entre 10 ya que se ejecuta cada segundo y dividirlo el damaga es una forma de que no quite tanto

    }
}