using Fusion;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.FusionNet.Gameplay.Player
{
    public class PlayerMovement : NetworkBehaviour
    {
        [SerializeField] private float _moveSpeed;

        public override void FixedUpdateNetwork()
        {
            if (GetInput(out PlayerInput input))
            {
                transform.position += input.Movement * _moveSpeed * Runner.DeltaTime;
            }
        }
    }
}