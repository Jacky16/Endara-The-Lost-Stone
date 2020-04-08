using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEstatuaManager : MonoBehaviour
{
    //Variables bool para saber si las estatuas estan en su sitio
    bool isSolutionFirst;
    bool isSolutionSecond;
    bool isSolutionThird;

    [SerializeField]
    Enterchallenge enterchallenge;
    [SerializeField]
    BossManager bossManager;
    [SerializeField]
    TimeManager _timeManager;
    public void SetSolutionFirst(bool b) // Estatua 1
    {
        isSolutionFirst = b;
        CheckSolution();
    }
    public void SetSolutionSecond(bool b)//Estatua 2
    {
        isSolutionSecond = b;
        CheckSolution();
    }
    public void SetSolutionThird(bool b)//Estatua 3
    {
        isSolutionThird = b;
        CheckSolution();
    }
    void CheckSolution()//Si esta resuelto
    {
        if(isSolutionFirst && isSolutionSecond && isSolutionThird)
        {
            //El player no puedo entrar otra vez a este reto si lo ha superado
            enterchallenge.CanEnter(false);
            //Restar una vida al boss
            bossManager.RestAttempBoss();
            //Parar la cuenta atras
            _timeManager.SetCanSubstractTime(false);
            return;
        }
    }
}
