using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using HK.UnitySequencerSystem.Standard;
using TMPro;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class Test : MonoBehaviour
    {
        [SerializeReference, SubclassSelector()]
        private List<ISequence> runOnceSequences = default;

        [SerializeReference, SubclassSelector()]
        private List<ISequence> runLoopSequences = default;

        [SerializeField]
        private GameObject target = default;

        [SerializeField]
        private List<TMP_Text> texts = default;

        private CancellationTokenSource scope = new();

        async void Start()
        {
            // シーケンスを定義する
            var sequences = new List<ISequence>
            {
                new WaitUntilLegacyInput(WaitUntilLegacyInput.InputKeyType.Down, KeyCode.Space),
            };

            // シーケンスが参照するコンテナを定義する（今回は何も登録しない）
            var container = new Container();

            // シーケンサを定義する
            var sequencer = new Sequencer(container, sequences);

            // シーケンスを実行する（終了するまで待機可能）
            await sequencer.PlayAsync(this.destroyCancellationToken);


            var _container = new Container();
            _container.Register(target.name, target.transform);
            foreach (var t in this.texts)
            {
                _container.Register(t.name, t);
            }
            _container.Register("MyDeltaTime", new Func<float>(() => 0.01f));
            var runOnceSequencer = new Sequencer(_container, this.runOnceSequences);
            var runLoopSequencer = new Sequencer(_container, this.runLoopSequences);
            runOnceSequencer.PlayAsync(scope.Token).Forget();
            runLoopSequencer.PlayLoopAsync(PlayerLoopTiming.Update, scope.Token).Forget();
        }
    }
}
