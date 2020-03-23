using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
public class GemaPuzzle : MonoBehaviour
{
    [SerializeField] GameObject gameObjectSolution;
    [SerializeField] CinemachineVirtualCamera camera;
    Animator anim;
    bool isSolution;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Solution(bool b)
    {
        isSolution = b;
        anim.SetBool("Iluminate", IsSolution());
        if (isSolution)
        {
            //StartCoroutine(CameraSwitch());
        }
    }
    IEnumerator CameraSwitch()
    {
        camera.Priority = 10;
        yield return new WaitForSeconds(1.5f);
        gameObjectSolution.SetActive(false);

        yield return new WaitForSeconds(1.5f);
        camera.Priority = 0;

    }
    public bool IsSolution()
    {
        return isSolution;
    }
}
