# UnitySequencerSystem
UnitySequencerSystem(以下、USS)はUnityでシンプルなシーケンス処理を実現するライブラリです。
汎用性が高いため、会話システムや敵弾の移動アルゴリズム、AIなどあらゆる分野で幅広く利用可能です。

![7sf4z-9zasm (1)](https://github.com/gif-hara/UnitySequencerSystem/assets/5396546/f9dca682-43f8-42eb-a349-a6c4c0e4970a)

## 目次
1. [どうやって使うの？](#どうやって使うの)
2. [インストール](#インストール)
3. [基本機能](#基本機能)
    1. [Log](#Log)
    2. [Delay](#Delay)

## どうやって使うの？
下記コードのようにシーケンス、コンテナ、シーケンサを定義することで実行が可能です。
```csharp
using System.Collections.Generic;
using UnitySequencerSystem;
using UnityEngine;

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

## インストール
UPM Managerにて配布しています。
```
https://github.com/gif-hara/UnitySequencerSystem.git?path=Assets/Plugins/UnitySequencerSystem
```
また以下のプラグインに対応しています。各プラグインがUPM Manager経由でインストールされている場合は自動的に利用可能になります。
- [UniTask](https://github.com/Cysharp/UniTask)
- [Unity-SerializeReferenceExtensions](https://github.com/mackysoft/Unity-SerializeReferenceExtensions)
- TextMeshPro
- InputSystem  

## 基本機能
- USSには基本的な機能として以下のシーケンスを用意しています（随時追加予定です）

### Log
- 与えられた文字列を`Debug.Log`に出力します。
```csharp
using System.Collections.Generic;
using UnitySequencerSystem;
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
```

### Delay
- 与えられた秒数待機します。
```csharp
using System.Collections.Generic;
using UnitySequencerSystem;
using UnityEngine;

public class Test : MonoBehaviour
{
    async void Start()
    {
        var sequences = new List<ISequence>
        {
            new Log("Begin"),
            new Delay(1.0f),
            new Log("One second has passed"),
        };
        var container = new Container();
        var sequencer = new Sequencer(container, sequences);
        await sequencer.PlayAsync(this.destroyCancellationToken);
    }
}
```

## Resolverクラス
Resolverクラスは操作を行う対象の参照を解決するクラスです。例えばTransformSetPositionはTransformの座標を設定しますが、
```
var sequences = new List<ISequence>
{
    new TransformSetPosition(
        new TransformResolver.Reference(transform),
        new Vector3Resolver.Constant(new Vector3(0, 0, 0))
    )
};
var container = new Container();
var sequencer = new Sequencer(container, sequences);
await sequencer.PlayAsync(CancellationToken.None);
```

## 具体的な例
- USSは名前の通り、シーケンシャルな処理に特化しています。これはゲーム制作には欠かせないアルゴリズムであり、それを柔軟に組み立てることが可能です
- いくつか例を以下に示します
### 真っ直ぐに移動する弾
- TODO
### 指定したオブジェクトを追従する弾
- TODO
### 会話システム
- TODO
### タワーディフェンスゲームのWAVEの仕組み
- TODO
### RPGの攻撃処理
- TODO
  
