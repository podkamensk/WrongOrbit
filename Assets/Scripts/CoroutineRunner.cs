using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WrongOrbit
{
    internal sealed class CoroutineRunner : MonoBehaviour
    {
        private void Start()
        {
            DontDestroyOnLoad(this);
        }

        public void RunCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(MonitorRunning(coroutine));
        }

        IEnumerator MonitorRunning(IEnumerator coroutine)
        {
            while (coroutine.MoveNext())
            {
                yield return coroutine.Current;
            }

            Destroy(gameObject);
        }

        public void OnDestroy()
        {
            Destroy(gameObject);
        }
    }
}

