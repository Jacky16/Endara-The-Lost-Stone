using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Puzzle2Manager : MonoBehaviour
{
    bool _column1;
    bool _column2;
    bool _column3;
    [SerializeField]
    PlayableDirector playableDirector;
    [Header("Animator columnas")]

    [SerializeField]
    Animator animColumn_1;

    [SerializeField]
    Animator animColumn_2;

    [SerializeField]
    Animator animColumn_3;


    public void Column1(bool b)
    {
        _column1 = b;
        animColumn_1.SetTrigger("SwitchColor");
        CheckSoulution();
    }
    public void Column2(bool b)
    {
        _column2 = b;
        animColumn_2.SetTrigger("SwitchColor");
        CheckSoulution();
    }
    public void Column3(bool b)
    {
        _column3 = b;
        animColumn_3.SetTrigger("SwitchColor");
        CheckSoulution();
    }
    void CheckSoulution()
    {
        if(_column1 && _column2 && _column3) 
        {
            print("Has solucionado el puzzle 2");
            Invoke("PlayCinematic", 1.5f);
        }
    }
    void PlayCinematic()
    {
        playableDirector.Play();
    }
}
