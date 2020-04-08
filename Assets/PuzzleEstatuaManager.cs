using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEstatuaManager : MonoBehaviour
{
    [SerializeField]
    bool isSolutionFirst;
    bool isSolutionSecond;
    bool isSolutionThird;

    [SerializeField]
    bool isPuzzleSolution;
    [SerializeField]
    Enterchallenge enterchallenge;
    [SerializeField]
    BossManager bossManager;
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
            isPuzzleSolution = true;
            enterchallenge.CanEnter(false);
            bossManager.RestAttempBoss();
            return;
        }
    }
}
