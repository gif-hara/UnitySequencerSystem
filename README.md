# UnitySequencerSystem
- Unityでシンプルなシーケンス処理を実現するライブラリです。
- 汎用性が高いため、会話システムや敵弾の移動アルゴリズム、AIなど幅広く利用可能です。

![7sf4z-9zasm (1)](https://github.com/gif-hara/UnitySequencerSystem/assets/5396546/f9dca682-43f8-42eb-a349-a6c4c0e4970a)

# 目次
1. [どうやって使うの？](#どうやって使うの)
2. [思想](#思想)
3. [基本機能](#基本機能)

# どうやって使うの？
- 下記コードのようにシーケンス、コンテナ、シーケンサを定義することで実行が可能です。
```csharp
using System.Collections.Generic;
using HK.UnitySequencerSystem;

public class Test : MonoBehaviour
{
    async void Start()
    {
        // シーケンスを定義する
        var sequences = new List<ISequence>
        {
            new Log("Start Press Space Key"),
            new WaitUntilLegacyInput(WaitUntilLegacyInput.InputKeyType.Down, KeyCode.Space),
            new Log("Pressed Space!")
        };
    
        // シーケンスが参照するコンテナを定義する（今回は何も登録しない）
        var container = new Container();
    
        // シーケンサを定義する
        var sequencer = new Sequencer(container, sequences);
    
        // シーケンスを実行する（終了するまで待機可能）
        await sequencer.PlayAsync(this.destroyCancellationToken);
    
        Debug.Log("End");
    }
}
```

# 思想
- `ISequence`は特定のオブジェクトの参照は持ちません
  - 代わりに`Container`にオブジェクトの参照を持たせます
  - `ISequence`は自分自身の仕事をこなすためのデータのみを持ち、必要な参照は`Container`から取得する方式を取っています

# 基本機能
- TODO
