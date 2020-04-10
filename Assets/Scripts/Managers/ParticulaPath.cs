using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class ParticulaPath : MonoBehaviour
{
  
    [SerializeField]
    GameObject prefabParticle;
    public bool canInstantiate;
    float currentTime = 0;
    [SerializeField]
    float timeSpawning;
    private void Update()
    {
        float globalTime = 0;
        currentTime += Time.deltaTime;
        if (canInstantiate)
        { 
            if (currentTime >= 3f)
            {
                GameObject g = Instantiate(prefabParticle, transform.position, Quaternion.identity);
                Destroy(g, 10);
                    
                currentTime = 0;

            } 
        }
        globalTime += Time.deltaTime;
        if(globalTime > timeSpawning)
        {
            canInstantiate = false;
            Destroy(gameObject);
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInstantiate = true;
        }
    }
}