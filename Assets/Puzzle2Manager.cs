using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2Manager : MonoBehaviour
{
    public bool _column1;
    public bool _column2;
    public bool _column3;

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
        }
    }
}
