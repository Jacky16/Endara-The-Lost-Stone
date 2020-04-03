using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceStatue : MonoBehaviour
{
    public PuzzleEstatuaManager puzzleEstatuaManager;
    public enum Orden { Primera,Segunda,Tercera};
    public Orden orden;
    private void OnTriggerStay(Collider other)
    {
        if(Orden.Primera == Orden.Primera)
        {
            if(other.gameObject.name == "State1")
            {
                puzzleEstatuaManager.SetSolutionFirst(true);
            }
        }
        if(Orden.Segunda == Orden.Segunda)
        {
            if(other.gameObject.name == "State2")
            {
                puzzleEstatuaManager.SetSolutionSecond(true);
            }
        }
        if(Orden.Tercera == Orden.Tercera)
        {
            if(other.gameObject.name == "State3")
            {
                puzzleEstatuaManager.SetSolutionThird(true);
            }
        }
    }
}
