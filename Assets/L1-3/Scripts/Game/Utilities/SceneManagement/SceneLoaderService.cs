using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace L1_3.Scripts.Game.Utilities.SceneManagement
{
    public class SceneLoaderService
    {
        public IEnumerator LoadAsync(Scenes sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            AsyncOperation wait = SceneManager.LoadSceneAsync(sceneName.ToString(), loadSceneMode);
            
            if (wait == null)
                throw new ArgumentException($"{sceneName} couldn't be found");

            yield return new WaitUntil(() => wait.isDone);
        }

        public IEnumerator UnloadAsync(Scenes sceneName)
        {
            AsyncOperation wait = SceneManager.UnloadSceneAsync(sceneName.ToString());
            
            if (wait == null)
                throw new ArgumentException($"{sceneName} couldn't be found");

            yield return new WaitUntil(() => wait.isDone);
        }
    }
}