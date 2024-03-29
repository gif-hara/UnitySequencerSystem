# UnitySequencerSystem
UnitySequencerSystem(以下、USS)はUnityでシンプルなシーケンス処理を実現するライブラリです。
汎用性が高いため、会話システムや敵弾の移動アルゴリズム、AIなどあらゆる分野で幅広く利用可能です。

![7sf4z-9zasm (1)](https://github.com/gif-hara/UnitySequencerSystem/assets/5396546/f9dca682-43f8-42eb-a349-a6c4c0e4970a)

## 目次
- [どうやって使うの？](#どうやって使うの)
- [インストール](#インストール)
- [Resolverクラス](#resolverクラス)
- [基本機能](#基本機能)
- [具体的な例](#具体的な例)


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
  - UniTaskを利用しない場合はTaskを利用しています。
  - 一部のUnity関連の操作をするシーケンスはとりあえずの対応は行っていますが基本的にUniTaskを利用するのをお勧めします。
- [Unity-SerializeReferenceExtensions](https://github.com/mackysoft/Unity-SerializeReferenceExtensions)
- [LitMotion](https://github.com/AnnulusGames/LitMotion)
- TextMeshPro
- InputSystem

Unity-SerializeReferenceExtensionsを利用することでInspectorで定義をすることも可能です。
![image](https://github.com/gif-hara/UnitySequencerSystem/assets/5396546/95fdff5c-db2c-493f-ad1d-094997f2f57d)

## Resolverクラス
Resolverクラスは操作を行う対象の参照を解決するクラスです。
例えばTransformSetPositionはTransformの座標を設定しますが、そのTransformはResolverクラスを通して参照することができます。
```csharp
// 直接Transformを参照する
var sequences = new List<ISequence>
{
    new TransformSetPosition(
        new TransformResolver.Reference(transform),
        new Vector3Resolver.Constant(new Vector3(0, 0, 0))
    )
};
var container = new Container();
var sequencer = new Sequencer(container, sequences);
await sequencer.PlayAsync(this.destroyCancellationToken);
```
コンテナに登録されたTransformを参照することも可能です。
```csharp
const string name = "Test";
var sequences = new List<ISequence>
{
    new TransformSetPosition
    (
        new TransformResolver.Name(name),
        new Vector3Resolver.Constant(new Vector3(0, 0, 0))
    ),
};
var container = new Container();
container.Register(name, this.target.transform);
var sequencer = new Sequencer(container, sequences);
await sequencer.PlayAsync(this.destroyCancellationToken);
```

## 基本機能
USSには基本的な機能として以下のシーケンスを用意しています（随時追加予定です）

### Log
与えられた文字列を`Debug.Log`に出力します。

### LogContainer
コンテナに登録されているオブジェクトすべてを`Debug.Log`に出力します。

### Delay
与えられた秒数待機します。

### その他随時実装中
様々な型に随時対応しています。現在、以下のクラスの機能を提供しています。
- Float
- GameObject
- Forget
- If
- InputSystem
- Int
- Particle
- TextMeshPro
- Transform
- Update
- Vector2
- Vector3
- WaitUntil
- WhenAll
- WhenAny


## 具体的な例

USSは名前の通り、シーケンシャルな処理に特化しています。これはゲーム制作には欠かせないアルゴリズムであり、それを柔軟に組み立てることが可能です。以下にサンプルを用意しました。Unityにインポートする方法は以下となります。
1. UnityメニューのWindow/Package Managerを選択する
2. Package Managerウィンドウ内のUnitySequencerSystemを選択する
3. 右側のSamplesタブから任意のサンプルをインポートする

![Sample01 UPM](./img/Sample01_UPM.png)

### Sample01 真横に移動する弾
![Sample01](./img/Sample01.gif)

シンプルにプレイヤー位置に弾を生成するシーケンスと弾の移動処理を担うシーケンス行います。
確認する場合はUPM ManagerのSamplesタグからSample01をImportしてください。

### 会話システム
- TODO

### RPGの攻撃処理
- TODO
  
