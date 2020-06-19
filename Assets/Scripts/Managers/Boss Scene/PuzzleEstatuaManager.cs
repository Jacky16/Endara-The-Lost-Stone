using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleEstatuaManager : MonoBehaviour
{
    //Variables bool para saber si las estatuas estan en su sitio
    bool isSolutionFirst;
    bool isSolutionSecond;
    bool isSolutionThird;
    public UnityEvent OnChallengeComplete;
    [SerializeField]
    Enterchallenge enterchallenge;

    [SerializeField]
    BossManager bossManager;

    [SerializeField]
    TimeManager _timeManager;

    [Header("Posicion de la puerta del Reto")]
    [SerializeField]
    Transform _positionDoorChallenge;
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
            //Restar una vida al boss y sacar al player del reto
            bossManager.SubstractAttempBoss(_positionDoorChallenge);
            //Parar la cuenta atras
            _timeManager.SetCanSubstractTime(false);
            bossManager.DoAnimationBoss(2);
            bossManager.SetCanOpenChallenge_1(false);
            bossManager.SetCanOpenChallenge_2(false);
            bossManager.SetCanOpenChallenge_3(true);
            OnChallengeComplete.Invoke();
            return;
        }
    }
}
