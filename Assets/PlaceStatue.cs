using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceStatue : MonoBehaviour
{
    [SerializeField]
    PuzzleEstatuaManager _puzzleEstatuaManager;
    [SerializeField]
    TimeManager timeManager;
    public enum SortStatue { Primera, Segunda, Tercera };
    public SortStatue sortStatue;

private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("State"))
        {
            State state;
            if (other.TryGetComponent<State>(out state))
            {
                switch (sortStatue)
                {
                    case SortStatue.Primera:
                        if(other.gameObject.name == "State1")
                        {
                            other.transform.SetParent(transform);
                            other.transform.DOLocalMove(new Vector3(0, 0, 0), 1).OnComplete(() => _puzzleEstatuaManager.SetSolutionFirst(true));
                        }
                       
                       
                        break;
                    case SortStatue.Segunda:
                        if (other.gameObject.name == "State2")
                        {
                            other.transform.SetParent(transform);
                            other.transform.DOLocalMove(new Vector3(0, 0, 0), 1).OnComplete(() => _puzzleEstatuaManager.SetSolutionSecond(true));
                        }
                       
                        break;
                    case SortStatue.Tercera:
                        if (other.gameObject.name == "State3")
                        {
                            other.transform.SetParent(transform);
                            other.transform.DOLocalMove(new Vector3(0, 0, 0), 1).OnComplete(() => _puzzleEstatuaManager.SetSolutionThird(true));
                        }
                       
                        break;
                }
            }
        }
        if(other.gameObject.name == "State")
        {
            timeManager.SubstractTime(200);
        }
        //other.transform.SetParent(transform);
        //other.transform.DOLocalMove(new Vector3(0, 0, 0), 1).OnComplete(() => puzzleEstatuaManager.SetSolutionFirst(true));
    }
   
}
