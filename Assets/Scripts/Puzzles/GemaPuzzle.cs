using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;
public class GemaPuzzle : MonoBehaviour
{
    [SerializeField] GameObject gameObjectSolution;
    [SerializeField] CinemachineVirtualCamera camera;
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] ParticleSystem [] _gemaParticleSystems;
  
    Animator anim;
    static bool isSolution;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void SolutionInGema(bool b)
    {
        isSolution = b;
        anim.SetBool("Iluminate", IsSolution());
       
    }
    IEnumerator CameraSwitch() // Se ejecuta en la animacion con un evento
    {
       
        camera.Priority = 10;
        yield return new WaitForSeconds(1.5f);
        gameObjectSolution.transform.DOShakePosition(.5f,1f).SetEase(Ease.Linear).OnComplete(() => Explode());

        yield return new WaitForSeconds(2.5f);
        camera.Priority = 0;

    }
    void Particles()
    {
        foreach (ParticleSystem p in _gemaParticleSystems)
        {
            p.Play();
            break;
        }
    }
    void Explode()
    {
        gameObjectSolution.SetActive(false);
        particleSystem.Play();
    }
    public static bool IsSolution()
    {
        return isSolution;
    }
}
