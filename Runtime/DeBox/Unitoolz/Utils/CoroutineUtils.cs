using System.Collections;
using UnityEngine;


namespace DeBox.Unitoolz.Utils
{
    internal class __CoroutineRunner : MonoBehaviour
    {
    }

    public static class CoroutineUtils
    {
        private static __CoroutineRunner _runner = null;

        public static Coroutine RunCoroutine(IEnumerator enumerable, MonoBehaviour owner = null)
        {
            if (owner == null)
            {
                owner = GetOrCacheTweenRunner();
            }

            return owner.StartCoroutine(enumerable);
        }

        private static __CoroutineRunner GetOrCacheTweenRunner()
        {
            if (_runner == null)
            {
                var runnerGameObject = new GameObject("TweenRunner");
                runnerGameObject.hideFlags = HideFlags.HideAndDontSave;
                Object.DontDestroyOnLoad(runnerGameObject);
                _runner = runnerGameObject.AddComponent<__CoroutineRunner>();
            }

            return _runner;
        }
    }
}