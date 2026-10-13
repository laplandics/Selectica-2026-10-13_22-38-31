using System.Collections;
using UnityEngine;

namespace Selectica
{
    public static class Coroutines
    {
        internal class CoroutineHolder : MonoBehaviour { }
        private static CoroutineHolder _coroutineHolder;
        
        private static void Initialize()
        {
            _coroutineHolder = new GameObject("[COROUTINES]").AddComponent<CoroutineHolder>();
            Object.DontDestroyOnLoad(_coroutineHolder.gameObject);
        }
        
        public static Coroutine Start(IEnumerator enumerator, MonoBehaviour coroutineHolder = null)
        {
            if (_coroutineHolder == null) Initialize();
            
            if (coroutineHolder == null) coroutineHolder = _coroutineHolder;
            return enumerator == null ? null : coroutineHolder.StartCoroutine(enumerator);
        }
        
        public static void Stop(Coroutine coroutine, MonoBehaviour coroutineHolder = null)
        {
            if (coroutine == null) return;
            if (coroutineHolder == null) coroutineHolder = _coroutineHolder;
            coroutineHolder.StopCoroutine(coroutine);
        }
    }
}