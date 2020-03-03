using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
public class GemaPuzzle : MonoBehaviour
{
    [SerializeField] GameObject gameObjectSolution;
    [SerializeField] CinemachineVirtualCamera camera;
    bool isSolution;
    
    public void Solution(bool b)
    {
        isSolution = b;
        if (isSolution)
        {
            StartCoroutine(CameraSwitch());
        }
    }
    IEnumerator CameraSwitch()
    {
        camera.Priority = 10;
        yield return new WaitForSeconds(1f);
        gameObjectSolution.transform.DOMoveY(-10, 1);

        yield return new WaitForSeconds(1f);
        camera.Priority = 0;

    }
    public bool IsSolution()
    {
        return isSolution;
    }
}
