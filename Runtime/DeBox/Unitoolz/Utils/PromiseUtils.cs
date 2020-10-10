using System.Collections;
using RSG;
using UnityEngine;


namespace DeBox.Unitoolz.Utils
{
    public static class PromiseUtils
    {
        public static IEnumerator WaitForPromise(IPromise promise)
        {
            bool isComplete = false;
            promise.Done(() => isComplete = true);
            while (!isComplete)
            {
                yield return null;
            }
        }
        
        public static IPromise WaitFrames(int frameCount, MonoBehaviour owner = null)
        {
            var result = new Promise();
            CoroutineUtils.RunCoroutine( WaitFramesCoroutine (frameCount, result), owner);
            return result;
        }
        
        public static IPromise WaitSeconds(float duration, MonoBehaviour owner = null)
        {
            var result = new Promise();
            CoroutineUtils.RunCoroutine( WaitSecondsCoroutine (duration, result), owner);
            return result;
        }
        
        private static IEnumerator WaitFramesCoroutine(int frameCount, Promise result)
        {
            for (int i = 0; i < frameCount; i++) { yield return null; }
            result.Resolve();
        }

        private static IEnumerator WaitSecondsCoroutine(float duration, Promise result)
        {
            yield return new WaitForSeconds(duration);
            result.Resolve();
        }
    }
}

