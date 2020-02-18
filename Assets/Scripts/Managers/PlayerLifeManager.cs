using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class PlayerLifeManager : MonoBehaviour
{
    [SerializeField] float maxLifePlayer = 100;
    public float currentLifePlayer;
    private PlayerMovement player;
    [SerializeField] Image imageLife;
    [SerializeField] RectTransform rectTransformLifeBar;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        currentLifePlayer = maxLifePlayer;
    }

    public void RestarLife(float life)
    {
        currentLifePlayer -= life;
        float porcentaje = (LifePlayer() * 1) / 100;
        imageLife.fillAmount = porcentaje;
        Debug.Log("Vida del player: " + currentLifePlayer);
        if (currentLifePlayer <= 0)
        {
            player.PlayerDead();
        }
    }

    public float LifePlayer()
    {
        return currentLifePlayer;
    }
   
}
