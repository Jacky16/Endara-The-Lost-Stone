using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class PlayerLifeManager : MonoBehaviour
{
    [SerializeField] 
    float _maxAttemps = 3;
    [SerializeField]
    float _currentAttemps;
    private PlayerMovement _player;

    [SerializeField] 
    Image [] _imagesLife;
    [SerializeField] 
    float numHeards;

    private void Awake()
    {
        _player = GetComponent<PlayerMovement>();
    }
    private void Start()
    {
        _currentAttemps = _maxAttemps;
        numHeards = _imagesLife.Length;
        LifeSpritesManager();
    }

    public void SubstractLife()
    {
        _currentAttemps --;
        Debug.Log("Vida del player: " + _currentAttemps);
        LifeSpritesManager();
        if(_currentAttemps == 0)
        {
            _player.PlayerDead();
        }
    }
    public float AttempsPlayer()
    {
        return _currentAttemps;
    }
    public void SetLifeToMax()
    {
        _currentAttemps = _maxAttemps;
        LifeSpritesManager();
        print(_currentAttemps);
    }
    void LifeSpritesManager()
    {
        float lifePorcentaje = (AttempsPlayer() * numHeards) / _maxAttemps;
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
