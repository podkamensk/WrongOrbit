using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WrongOrbit
{
    internal sealed class SceneClicker
    {
        private Scene _sceneName;
        private CoroutineRunner _coroutineRunner;


        public SceneClicker(CoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }
/*
        void LoadScene()
        {
            //Start loading the Scene asynchronously and output the progress bar
            _monobehClicker.StartCoroutine();
        }

        IEnumerator LoadScene()
        {
            yield return null;

        }

*/
        // called first
        void OnEnable()
        {
            Debug.Log("OnEnable called");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        // called second
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("OnSceneLoaded: " + scene.name);
            Debug.Log(mode);
        }

        // called third
        void Start()
        {
            Debug.Log("Start");
        }

        // called when the game is terminated
        void OnDisable()
        {
            Debug.Log("OnDisable");
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}

