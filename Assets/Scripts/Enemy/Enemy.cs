using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] int life = 100;
    [SerializeField] float attackDamage;
    [SerializeField] float velocity;
  


    
    private void Update()
    {
       // isInFov = InFov(transform, playerTransform, myMaxAngle, maxRadius);
    }
    
}
