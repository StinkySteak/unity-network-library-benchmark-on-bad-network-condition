using Netick.Unity;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.NetickNet.Gameplay.Player
{
    public class PlayerMovementAuto : NetworkBehaviour
    {
        [SerializeField] private MovementType _movementType;

        private IVelocityProvider _velocityProvider;

        public override void NetworkStart()
        {
            if (!IsInputSource) return;

            AssignVelocityProvider();
        }

        private void AssignVelocityProvider()
        {
            _velocityProvider = MovementTypeConstructor.GetVelocityProvider(_movementType);
            _velocityProvider.InitDefault();
        }

        public override void NetworkUpdate()
        {
            if (!IsInputSource) return;

            if(_movementType == MovementType.None) return;

            PlayerInput input = new();
            input.Movement = _velocityProvider.GetVelocity(transform, Sandbox.DeltaTime);

            Sandbox.SetInput(input);
        }
    }
}