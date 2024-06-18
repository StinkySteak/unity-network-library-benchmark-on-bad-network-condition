using Netick.Unity;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.NetickNet.Gameplay.Player
{
    public class PlayerMovement : NetworkBehaviour
    {
        [SerializeField] private float _moveSpeed;
        
        public override void NetworkFixedUpdate()
        {
            if (FetchInput(out PlayerInput input))
            {
                transform.position += input.Movement * _moveSpeed * Sandbox.FixedDeltaTime;
            }
        }
    }
}