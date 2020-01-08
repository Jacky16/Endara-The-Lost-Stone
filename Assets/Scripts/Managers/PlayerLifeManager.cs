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

    private void Update()
    {
        //Debug.Log("La vida player es: " + currentLifePlayer);
        ImageLifeManagerValue();
        if(currentLifePlayer <= 0)
        {
            player.PlayerDead();
        }
    }
    public void RestarLife(float life)
    {
        currentLifePlayer -= life;
        Debug.Log("Vida del player: " + currentLifePlayer);
       // rectTransformLifeBar.DOShakeAnchorPos(100f, 1);
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
