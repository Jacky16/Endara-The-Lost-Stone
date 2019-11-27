using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransitions : MonoBehaviour
{
    public Animator anim;

   
   public void SceneIndexToLoad(int numberIndex)
   {
        StartCoroutine(LoadSceneCoroutine(numberIndex));
   }
    IEnumerator LoadSceneCoroutine(int index)
    {
        anim.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(index);



    }
}
