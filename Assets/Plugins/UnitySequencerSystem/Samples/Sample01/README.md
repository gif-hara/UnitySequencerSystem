# UnitySequencerSystem Sample01

このサンプルでは、UnitySequencerSystemの基本的な使い方を紹介します。
プレイヤーとなるカプセルの座標に弾となるキューブを生成するシーケンス、その弾の動きを制御するシーケンスを確認できます。
サンプルではありますが以下前提条件のように、いくつかのプラグインを使うことで利便性を高めています。

## 前提条件

このサンプルを実行するには、以下の条件を満たす必要があります。これらはUPM Managerでインストールすることで自動的に利用できるようになります。
- [UniTask](https://github.com/Cysharp/UniTask)をインストールしていること
    - もしUPM Managerでインストールしていない場合はScript Define Symbolsに`USS_SUPPORT_UNITASK`を追加してください。
- [LitMotion](https://github.com/AnnulusGames/LitMotion)をインストールしていること
    - もしUPM Managerでインストールしていない場合はScript Define Symbolsに`USS_SUPPORT_LIT_MOTION`を追加してください。
- [Unity-SerializeReferenceExtensions](https://github.com/mackysoft/Unity-SerializeReferenceExtensions)をインストールしていること
    - もしUPM Managerでインストールしていない場合はScript Define Symbolsに`USS_SUPPORT_SUB_CLASS_SELECTOR`を追加してください。

## スクリプトの説明
### Scripts/SceneController.cs
- ここではプレイヤーのTransformを参照し、Spaceキーが押されたら弾を生成するシーケンスを実行しています。
- また、弾の動きを制御するシーケンスを実行しています。
- 弾を生成しているときにPlayerの参照をコンテナに渡しているのがポイントです。
    - このようにシーケンス間で参照を渡すことでデータを共有することができます。
    - このサンプルでは、弾の動きを制御するシーケンスでPlayerの座標を参照しています。

## ScriptableSequencesの説明
### Sequences/SpawnBulletSequences.asset
- 弾の生成に必要な情報を持つシーケンスです。
- まずGameObject InstantiateシーケンスでCubeプレハブを生成し、コンテナにはBulletという名前で登録しています。
- 次にBulletのTransform情報が欲しいため、GameObject To TransformシーケンスでコンテナにBulletという名前で登録し直します。
- その後にTransform Set Positionを利用してPlayerの座標を参照し、弾の初期位置として設定します。
### Sequences/BulletBehaviourSequences.asset
- 弾の動きを制御するシーケンスです。
- 最初にVector3 Addを利用して弾の最終座標を算出しています。
- 次にLitMotionを利用したBind To Local Positionを利用して弾の座標を更新しています。
    - このシーケンスはawaitを利用しています。トゥイーンが終了するまで次のシーケンスには進みません。
- 最後にGame Object Destroyシーケンスを利用して弾を破棄しています。