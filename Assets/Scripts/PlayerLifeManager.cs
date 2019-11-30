using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerLifeManager : MonoBehaviour
{
    [SerializeField] float myLife = 100;
    private PlayerMovement player;
    [SerializeField] Image imageLife;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        ImageLifeManagerValue();
        if(myLife <= 0)
        {
            player.PlayerDead();
        }
    }
    public void RestarLife(int life)
    {
        myLife -= life; 
    }

    public float LifePlayer()
    {
        return myLife;
    }
    public void ImageLifeManagerValue()
    {
        float porcentaje = (myLife * 1) / 100;
        imageLife.fillAmount = porcentaje;
    }
}
