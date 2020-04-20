using Cinemachine;
using DG.Tweening;
using System.Collections;
using UnityEngine;
public class GemaPuzzle : MonoBehaviour
{
    [Header("Camaras")]
    [SerializeField]
    CinemachineVirtualCamera _cameraEsfera;

    [SerializeField]
    CinemachineVirtualCamera _cameraGema;

    [SerializeField]
    CinemachineFreeLook _cameraPlayer;

    [Header("Cupula")]
    [SerializeField] 
    GameObject gameObjectSolution;

    [Header("Particulas")]
    [SerializeField]
    ParticleSystem particleSystem;
    
    [SerializeField] 
    ParticleSystem [] _gemaParticleSystems;
  
    Animator anim;
    AudioSource _audioSource;

    [Header("Sonidos")]
    [SerializeField]
    AudioClip _audioClipGema;
    
    [SerializeField]
    AudioClip _audioClipCupula;

    [Header("Spawn Baldosas")]
    [SerializeField]
    SpawnBaldosas[] _spawnBaldosas;

    static bool isSolution;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    public void SolutionInGema(bool b)
    {
        isSolution = b;
        anim.SetBool("Iluminate", IsSolution());
       
    }
    IEnumerator CameraSwitch() // Se ejecuta en la animacion de la gema con un evento
    {
        _audioSource.PlayOneShot(_audioClipGema);
        _cameraGema.Priority = 10;

        yield return new WaitForSeconds(1);

        _cameraEsfera.Priority = 10;

        yield return new WaitForSeconds(1.5f);

        gameObjectSolution.transform.DOShakePosition(.5f,1f).SetEase(Ease.Linear).OnComplete(() => Explode());
        
        _cameraEsfera.Priority = 10;

        yield return new WaitForSeconds(2);

        _cameraGema.Priority = 0;
        _cameraEsfera.Priority = 0;
        _cameraPlayer.Priority = 1;
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
        
        _audioSource.PlayOneShot(_audioClipCupula);
        gameObjectSolution.SetActive(false);
        particleSystem.Play();
    }
    public static bool IsSolution()
    {
        return isSolution;
    }
}
