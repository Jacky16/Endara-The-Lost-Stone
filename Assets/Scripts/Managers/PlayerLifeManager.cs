using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class PlayerLifeManager : MonoBehaviour
{
    [SerializeField] 
    float _maxLifePlayer = 100;
    public float currentLifePlayer;
    private PlayerMovement _player;
    [SerializeField] Image [] _imagesLife;
    [SerializeField] float numHeards;


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        currentLifePlayer = _maxLifePlayer;
        numHeards = _imagesLife.Length;
    }

    public void RestarLife(float life)
    {
        currentLifePlayer -= life;

        Debug.Log("Vida del player: " + currentLifePlayer);
        LifeSpritesManager();

        if (currentLifePlayer <= 0)
        {
            _player.PlayerDead();
        }
    }

    public float LifePlayer()
    {
        return currentLifePlayer;
    }
    void LifeSpritesManager()
    {
        float lifePorcentaje = (LifePlayer() * numHeards) / 100;
        print(lifePorcentaje);
        for (int i = 0; i < _imagesLife.Length; i++)
        {
            if (i < lifePorcentaje)  // Mantiene los sprites activos si i es mas pequeño que la vida (en porcentaje)
            {
                _imagesLife[i].enabled = true;
            }
            else // Si i es mas grande que Life Porcentaje, desactiva todos los sprites mayor a i
            {
                _imagesLife[i].enabled = false;
            }
        }
    }


}
