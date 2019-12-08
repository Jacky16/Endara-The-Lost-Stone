using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerLifeManager : MonoBehaviour
{
    [SerializeField] float maxLifePlayer = 100;
    public float currentLifePlayer;
    private PlayerMovement player;
    [SerializeField] Image imageLife;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        currentLifePlayer = maxLifePlayer;
    }

    private void Update()
    {
        ImageLifeManagerValue();
        if(currentLifePlayer <= 0)
        {
            player.PlayerDead();
        }
    }
    public void RestarLife(int life)
    {
        currentLifePlayer -= life; 
    }

    public float LifePlayer()
    {
        return currentLifePlayer;
    }
    public void ImageLifeManagerValue()
    {
        float porcentaje = (currentLifePlayer * 1) / 100;
        imageLife.fillAmount = porcentaje;
    }
}
