# UnitySequencerSystem Sample01

This sample introduces the basic usage of the UnitySequencerSystem. It demonstrates a sequence for generating a cube bullet at the player's (represented as a capsule) coordinates, and a sequence for controlling the movement of the bullet. Although this is a sample, it enhances convenience by utilizing several plugins as indicated in the prerequisites below.

## Prerequisites

To execute this sample, the following conditions must be met. These can be automatically enabled after installation via UPM Manager:
- [UniTask](https://github.com/Cysharp/UniTask) should be installed.
    - If not installed via UPM Manager, add `USS_SUPPORT_UNITASK` to Script Define Symbols.
- [LitMotion](https://github.com/AnnulusGames/LitMotion) should be installed.
    - If not installed via UPM Manager, add `USS_SUPPORT_LIT_MOTION` to Script Define Symbols.
- [Unity-SerializeReferenceExtensions](https://github.com/mackysoft/Unity-SerializeReferenceExtensions) should be installed.
    - If not installed via UPM Manager, add `USS_SUPPORT_SUB_CLASS_SELECTOR` to Script Define Symbols.

## Script Explanation
### Scripts/SceneController.cs
- This script references the player's Transform and executes a sequence to generate a bullet when the Space key is pressed.
- It also executes a sequence to control the bullet's movement.
- The key point here is passing the reference to the Player to the container when generating the bullet.
    - By doing so, it allows for sharing data between sequences.
    - In this sample, the Player's coordinates are referenced in the sequence controlling the bullet's movement.
- Thus, the script defines only "bullet generation" and "bullet behavior," leaving other processes to the data side, reducing the amount of code needed.

## Explanation of ScriptableSequences
### Sequences/SpawnBulletSequences.asset
- A sequence that contains the necessary information to generate a bullet.
- First, a GameObject Instantiate sequence creates a Cube prefab, which is registered in the container as Bullet.
- Next, to obtain the Transform information of Bullet, the GameObject To Transform sequence re-registers it in the container as Bullet.
- Then, using Transform Set Position, it sets the bullet's initial position by referencing the Player's coordinates.
### Sequences/BulletBehaviourSequences.asset
- A sequence to control the bullet's movement.
- Initially, it uses Vector3 Add to calculate the bullet's final coordinates.
- Next, it updates the bullet's position using Bind To Local Position, which utilizes LitMotion.
    - This sequence uses await, not progressing to the next sequence until the tweening is complete.
- Finally, the bullet is disposed of using the Game Object Destroy sequence.