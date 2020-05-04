using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_1 : Enemy
{
    [SerializeField] GameObject explosionPrefab;

    [SerializeField]float damageExplosion = 14;
    
    public override void NearAttackPlayer()
    {
    }
    public override void FarAttackPlayer()
    {
        anim.SetTrigger("Explosion");
        Invoke("Explosion", 1.10f);
    }
    public void Explosion()
    {
        GameObject g = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
        //g.GetComponent<ExplosionEnemy1>().GetDamage(DamageExplosion());
        Debug.Log("He explotado");
        Destroy(this.gameObject, .01f);
    }
    public float DamageExplosion()
    {
        return damageExplosion/3.0f;
    }
    
    public void RestLife(float lifeToRest)
    {
        life -= lifeToRest;
        if(life <= 0)
        {
            GameObject g = Instantiate(explosionPrefab, transform.position, Quaternion.identity) as GameObject;
            //g.GetComponent<ExplosionEnemy1>().enabled = false;
            Destroy(this.gameObject,1);
        }
        print(life);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cola"))
        {
            Explosion();
        }
    }
   
    IEnumerator RestLifePlayer(Collider other)
    {
        yield return new WaitForSeconds(0.25f);
        other.GetComponent<PlayerLifeManager>().SubstractLife(); // Se divide entre 10 ya que se ejecuta cada segundo y dividirlo el damaga es una forma de que no quite tanto
        navMeshAgent.speed = 0;
    }
}