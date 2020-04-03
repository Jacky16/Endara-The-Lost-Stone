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
    public void SetSolutionFirst(bool b)
    {
        isSolutionFirst = b;
        CheckSolution();
    }
    public void SetSolutionSecond(bool b)
    {
        isSolutionSecond = b;
        CheckSolution();
    }
    public void SetSolutionThird(bool b)
    {
        isSolutionThird = b;
        CheckSolution();
    }
    void CheckSolution()
    {
        if(isSolutionFirst && isSolutionSecond && isSolutionThird)
        {
            isPuzzleSolution = true;
            enterchallenge.CanEnter(false);
        }
    }
}
