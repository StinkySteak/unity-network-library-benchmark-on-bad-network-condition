using Netick.Unity;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.NetickNet.Gameplay.Player
{
    public class LocalPlayerInputProvider : NetworkEventsListener
    {
        public override void OnInput(NetworkSandbox sandbox)
        {
            PlayerInput input = new();
            input.Movement = GetMovement();

            sandbox.SetInput(input);
        }

        private Vector3 GetMovement()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Camera camera = Camera.main;

            if(camera == null) return Vector3.zero;

            Vector3 right = horizontal * camera.transform.right;
            Vector3 forward = vertical * camera.transform.forward;
            Vector3 move = forward + right;

            Vector3 input = new Vector3(move.x, 0, move.z);

            return input;
        }
    }
}