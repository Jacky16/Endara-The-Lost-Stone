using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeManager : MonoBehaviour
{
    private int myLife = 100;
    private PlayerMovement player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(myLife <= 0)
        {
            player.PlayerDead();
        }
    }
    public void RestarLife(int life)
    {
        myLife -= life; 
    }

    public int LifePlayer()
    {
        return myLife;
    }
}
