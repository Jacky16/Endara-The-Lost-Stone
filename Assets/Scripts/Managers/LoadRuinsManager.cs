using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadRuinsManager : MonoBehaviour
{
    [SerializeField]
    Animator animFade;

    LevelLoader _levelLoader;
    bool isLoaded;
    private void Awake()
    {
        _levelLoader = GetComponent<LevelLoader>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isLoaded)
        {
            isLoaded = true;
            StartCoroutine(TransitionRuinsScene());
        }
    }
    IEnumerator TransitionRuinsScene()
    {
        animFade.SetTrigger("DeadCaida_Start");
        yield return new WaitForSeconds(1);
        _levelLoader.LoadScene();

    }
}
