using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace HK.UnitySequencerSystem.Core
{
    public class MainThreadDispatcher : MonoBehaviour
    {
        private static MainThreadDispatcher instance;

        public static MainThreadDispatcher Instance
        {
            get
            {
                if (instance == null)
                {
                    var go = new GameObject("USSMainThreadDispatcher");
                    instance = go.AddComponent<MainThreadDispatcher>();
                    DontDestroyOnLoad(go);
                }

                return instance;
            }
        }

        public Task RunCoroutineAsTask(IEnumerator coroutine)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            StartCoroutine(RunCoroutine(coroutine, taskCompletionSource));
            return taskCompletionSource.Task;
        }

        private IEnumerator RunCoroutine(IEnumerator coroutine, TaskCompletionSource<bool> taskCompletionSource)
        {
            yield return StartCoroutine(coroutine);
            taskCompletionSource.SetResult(true);
        }
    }
}
