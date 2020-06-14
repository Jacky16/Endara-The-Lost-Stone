using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaSaltosManager : MonoBehaviour
{
    [SerializeField]
    GameObject [] _gameObjectsPlattforms;

    [SerializeField]
    Transform _respawnPlayer;

    [Header("Referencias")]
    [SerializeField]
    TimeManager _timeManager;

    [SerializeField]
    Enterchallenge _enterchallenge;

    [SerializeField]
    BossManager _bossManager;

    [Header("Posicion de la puerta del Reto")]
    [SerializeField]
    Transform _positionDoorChallenge;


    List<GravityPlataform> _listGravityPlattforms = new List<GravityPlataform>();
    private void Start()
    {
        //Añadir las plataformas en la lista
        foreach(GameObject go in _gameObjectsPlattforms)
        {
            _listGravityPlattforms.Add(go.GetComponentInChildren<GravityPlataform>());
        }
        //Desactivar la gravedad de las plataformas
        foreach(GravityPlataform gp in _listGravityPlattforms)
        {
            gp.SetGravity(false);
        }

    }
    public void CheckSolution()//Si esta resuelto
    {
        //El player no puedo entrar otra vez a este reto si lo ha superado
        _enterchallenge.CanEnter(false);
        //Restar una vida al boss y sacar al player del reto
        _bossManager.SubstractAttempBoss(_positionDoorChallenge);
        //Ejecutar la animacion del boss
        _bossManager.DoAnimationBoss(3);
        //Parar la cuenta atras
        _timeManager.SetCanSubstractTime(false);
        return;    
    }
    public void ActivateGravityPlattforms()
    {
        foreach (GravityPlataform gp in _listGravityPlattforms)
        {
            gp.SetGravity(true);
        }
    }
    public void DisableGravityPlattforms()
    {
        foreach (GravityPlataform gp in _listGravityPlattforms)
        {
            gp.SetGravity(false);
        }
    }
    public void RestartPlattformsPositions()
    {
        foreach (GravityPlataform gp in _listGravityPlattforms)
        {
            gp.SetOriginalPosition();
        }
    }
    public Transform RespawnPlayer()
    {
        return _respawnPlayer;
    }
}
