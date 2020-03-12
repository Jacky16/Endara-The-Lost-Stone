using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_1 : Enemy
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField]bool explosionRand;
    [SerializeField]float damageExplosion = 14;
    private void Start()
    {
    }
    public override void NearAttackPlayer()
    {
        if (!explosionRand)
        {
            if (BetweenDistance < nearRadiusAttack && isInFov)
            {
                navMeshAgent.SetDestination(player.position);
                Debug.Log("Estoy atacando al player");
            }

        }
        else
        {
            if (BetweenDistance <= nearRadiusAttack)
            {
                Invoke("Explosion", 2);
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
    public override void FarAttackPlayer()
    {

    }

    public float Damage()
    {
        return attackDamage;
    }
    public void RestLife(float lifeToRest)
    {
        life -= lifeToRest;
        if(life <= 0)
        {
            Destroy(this.gameObject);
        }
        print(life);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cola"))
        {

            RestLife(other.GetComponent<DamegeAttack>().DamagePlayer());
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetTrigger("Attack");

            StartCoroutine(RestLifePlayer(other));

        }
    }
    IEnumerator RestLifePlayer(Collider other)
    {
        yield return new WaitForSeconds(0.25f);
        other.GetComponent<PlayerLifeManager>().RestarLife(attackDamage /50); // Se divide entre 10 ya que se ejecuta cada segundo y dividirlo el damaga es una forma de que no quite tanto
        navMeshAgent.speed = 0;
    }
}