using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnitySequencerSystem.Resolvers;
using UnitySequencerSystem.StandardSequences;

namespace UnitySequencerSystem.Samples.Sample01
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField]
        private Transform playerObject;

        [SerializeField]
        private ScriptableSequences spawnBulletSequence;

        [SerializeField]
        private ScriptableSequences bulletBehaviourSequence;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SpawnBulletAsync().Forget();
            }
        }

        private async UniTask SpawnBulletAsync()
        {
            var container = new Container();
            var spawnSequencer = new Sequencer(container, spawnBulletSequence.Sequences);
            await spawnSequencer.PlayAsync(this.destroyCancellationToken);
            var bulletBehaviourSequencer = new Sequencer(container, bulletBehaviourSequence.Sequences);
            await bulletBehaviourSequencer.PlayAsync(this.destroyCancellationToken);
        }
    }
}
