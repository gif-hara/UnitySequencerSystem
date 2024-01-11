using System.Collections.Generic;
using UnitySequencerSystem;
using UnitySequencerSystem.Standard;
using UnityEngine;

public class TestLog : MonoBehaviour
{
    async void Start()
    {
        var sequences = new List<ISequence>
        {
            new Log("Hello USS!"),
        };
        var container = new Container();
        var sequencer = new Sequencer(container, sequences);
        await sequencer.PlayAsync(this.destroyCancellationToken);
    }
}
