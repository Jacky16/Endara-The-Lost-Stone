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

    //Audio puzzle 2
    AudioSource audioSource;
    [SerializeField]
    AudioClip audioCorrectPuzzle;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Column1(bool b)
    {
        _column1 = b;
        CheckSoulution();
    }
    public void Column2(bool b)
    {
        _column2 = b;
        CheckSoulution();
    }
    public void Column3(bool b)
    {
        _column3 = b;
        CheckSoulution();
    }
    void CheckSoulution()
    {
        if(_column1 && _column2 && _column3) 
        {
            print("Has solucionado el puzzle 2");
            animColumn_1.SetTrigger("SwitchColor");
            animColumn_2.SetTrigger("SwitchColor");
            animColumn_3.SetTrigger("SwitchColor");
            Invoke("PlayCinematic", 1.5f);
        }
    }
    void PlayCinematic()
    {
        audioSource.PlayOneShot(audioCorrectPuzzle);
        playableDirector.Play();
        
        //Desactivar los objetos triggers para quitar la UI de rotar
        ColumnPuzzle2[] columnPuzzle2s = GetComponentsInChildren<ColumnPuzzle2>();
        foreach(ColumnPuzzle2 cp2 in columnPuzzle2s)
        {
            cp2.gameObject.SetActive(false);
        }
    }
}
