# UnitySequencerSystem Sample01

This sample introduces the basic usage of the UnitySequencerSystem. It includes a sequence for creating a cube bullet at the coordinates of the player, who is represented as a capsule, and a sequence to control the movement of this bullet. Although it is a sample, it enhances convenience by using several plugins as outlined in the following prerequisites.

## Prerequisites

To run this sample, the following conditions must be met. These can be automatically available after installation via UPM Manager:
- [UniTask](https://github.com/Cysharp/UniTask) is installed
    - If not installed via UPM Manager, add `USS_SUPPORT_UNITASK` to Script Define Symbols.
- [LitMotion](https://github.com/AnnulusGames/LitMotion) is installed
    - If not installed via UPM Manager, add `USS_SUPPORT_LIT_MOTION` to Script Define Symbols.
- [Unity-SerializeReferenceExtensions](https://github.com/mackysoft/Unity-SerializeReferenceExtensions) is installed
    - If not installed via UPM Manager, add `USS_SUPPORT_SUB_CLASS_SELECTOR` to Script Define Symbols.

## Script Descriptions
### Scripts/SceneController.cs
- This script refers to the player's Transform and executes a sequence to create a bullet when the Space key is pressed.
- It also executes a sequence to control the bullet's movement.
- A key point is that the reference to the Player is passed to the container when generating the bullet.
    - In this way, references can be shared between sequences.
    - In this sample, the Player's coordinates are referred to in the sequence that controls the bullet's movement.

## Description of ScriptableSequences
### Sequences/SpawnBulletSequences.asset
- A sequence containing the information necessary to generate a bullet.
- First, the GameObject Instantiate sequence creates a Cube prefab, which is registered in the container as Bullet.
- Then, to get the Transform information of Bullet, the GameObject To Transform sequence re-registers it in the container as Bullet.
- Afterwards, Transform Set Position is used to reference the Player's coordinates and set the bullet's initial position.
### Sequences/BulletBehaviourSequences.asset
- A sequence to control the bullet's movement.
- Initially, Vector3 Add is used to calculate the bullet's final coordinates.
- Next, the bullet's position is updated using Bind To Local Position, which utilizes LitMotion.
    - This sequence uses await and does

not proceed to the next sequence until the tweening is complete.
- Finally, the bullet is destroyed using the Game Object Destroy sequence.