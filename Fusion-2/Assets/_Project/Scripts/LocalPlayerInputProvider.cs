using Fusion;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.Fusion2Net.Gameplay.Player
{
    public class LocalPlayerInputProvider : NetworkRunnerCallbacksMono
    {
        public override void OnInput(NetworkRunner runner, NetworkInput input)
        {
            PlayerInput playerInput = new();
            playerInput.Movement = GetMovement();

            input.Set(playerInput);
        }

        private Vector3 GetMovement()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Camera camera = Camera.main;

            Vector3 right = horizontal * camera.transform.right;
            Vector3 forward = vertical * camera.transform.forward;
            Vector3 move = forward + right;

            Vector3 input = new Vector3(move.x, 0, move.z);

            return input;
        }
    }
}