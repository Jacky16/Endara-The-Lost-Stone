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
    [Header("Vidas Sprite")]
    [SerializeField] GameObject imageLife_1;
    [SerializeField] GameObject imageLife_2;
    [SerializeField] GameObject imageLife_3;
    [SerializeField] GameObject imageLife_4;
    [SerializeField] GameObject imageLife_5;
    [SerializeField] GameObject imageLife_6;
    [SerializeField] GameObject imageLife_7;
    [SerializeField] GameObject imageLife_8;
    [SerializeField] GameObject imageLife_9;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        currentLifePlayer = maxLifePlayer;
    }
    private void Update()
    {
        //currentLifePlayer -= Time.deltaTime * 4;
    }
    private void FixedUpdate()
    {
        LifeSpritesManager();

    }

    public void RestarLife(float life)
    {
        currentLifePlayer -= life;
        float porcentaje = (LifePlayer() * 1) / 100;
        //imageLife.fillAmount = porcentaje;
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
    void LifeSpritesManager()
    {
        if (currentLifePlayer < 100)
        {
            imageLife_1.SetActive(false);  

        } 
        if (currentLifePlayer <= 89)
        {
            imageLife_2.SetActive(false);

        }
         if (currentLifePlayer <= 78)
        {
            imageLife_3.SetActive(false);

        }
         if (currentLifePlayer <= 67)
        {
            imageLife_4.SetActive(false);

        }
         if (currentLifePlayer <= 56)
        {
            imageLife_5.SetActive(false);

        }
         if (currentLifePlayer <= 45)
        {
            imageLife_6.SetActive(false);

        }
         if (currentLifePlayer <= 34)
        {
            imageLife_7.SetActive(false);

        }
         if (currentLifePlayer <= 23)
        {
            imageLife_8.SetActive(false);

        }
         if (currentLifePlayer <= 12)
        {
            imageLife_9.SetActive(false);

        }




    }
    
   
}
