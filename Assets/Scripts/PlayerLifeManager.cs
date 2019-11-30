using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerLifeManager : MonoBehaviour
{
    private int myLife = 100;
    private PlayerMovement player;
    [SerializeField] Image imageLife;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        CalcularPorcentajeVida();
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
    public void CalcularPorcentajeVida()
    {
        int porcentaje = (myLife * 1) / myLife;
        imageLife.fillAmount = porcentaje;
    }
}
