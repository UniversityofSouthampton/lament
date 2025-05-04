using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
   [SerializeField] private float _sceneFadeDuration;


   private SceneFade _sceneFade;

   private void Awake()
   {
      _sceneFade = GetComponentInChildren<SceneFade>();

      if(_sceneFade != null)
      {
        Debug.LogError("SceneFade component has been found in children!");
      
      }
      DontDestroyOnLoad(gameObject);
   }

   private IEnumerator Start()
   {
      yield return _sceneFade.FadeInCoroutine(_sceneFadeDuration);
   }

   public void LoadScene(string sceneName)
   {
      StartCoroutine(LoadSceneCoroutine(sceneName));
   }

   private IEnumerator LoadSceneCoroutine(string sceneName)
   {  
      //yield return _sceneFade.FadeOutCoroutine(_sceneFadeDuration);
      //yield return new WaitForSeconds(1f);
      yield return SceneManager.LoadSceneAsync(sceneName);
   }
}
