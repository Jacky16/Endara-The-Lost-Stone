using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class PlayerLifeManager : MonoBehaviour
{
    [SerializeField] 
    float _maxLifePlayer = 100;
    [SerializeField]
    float _currentLifePlayer;
    private PlayerMovement _player;

    [SerializeField] 
    Image [] _imagesLife;
    [SerializeField] 
    float numHeards;


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        _currentLifePlayer = _maxLifePlayer;
        numHeards = _imagesLife.Length;
    }

    public void RestarLife(float life)
    {
        _currentLifePlayer -= life;

        Debug.Log("Vida del player: " + _currentLifePlayer);
        LifeSpritesManager();

        if (_currentLifePlayer <= 0)
        {
            _player.PlayerDead();
        }
    }

    public float LifePlayer()
    {
        return _currentLifePlayer;
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
