using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlatformsManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] _gameObjectsPlattforms;
    List<GravityPlataform> _listGravityPlattforms = new List<GravityPlataform>();
    private void Start()
    {
        //Añadir las plataformas en la lista
        foreach (GameObject go in _gameObjectsPlattforms)
        {
            _listGravityPlattforms.Add(go.GetComponentInChildren<GravityPlataform>());
        }
        //Desactivar la gravedad de las plataformas
        foreach (GravityPlataform gp in _listGravityPlattforms)
        {
            gp.SetGravity(false);
        }
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
}
