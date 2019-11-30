using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEnemy1 : MonoBehaviour
{
    [SerializeField] int damageExplosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerLifeManager playerLifeManager = GameObject.Find("Player Life Manager").GetComponent<PlayerLifeManager>();
            playerLifeManager.RestarLife(damageExplosion);
        }
    }
    private void Update()
    {
        Destroy(gameObject, 2);
    }
}
