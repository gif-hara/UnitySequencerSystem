using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitySequencerSystem.Samples.Sample01
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField]
        private Transform playerObject;

        [SerializeField]
        private float playerSpeed = 1;

        void Update()
        {
            var velocity = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                velocity.y = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                velocity.y = -1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                velocity.x = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                velocity.x = 1;
            }
            velocity.Normalize();
            playerObject.position += velocity * Time.deltaTime * playerSpeed;
        }
    }
}
