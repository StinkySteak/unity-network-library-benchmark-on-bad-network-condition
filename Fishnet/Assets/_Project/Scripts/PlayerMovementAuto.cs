using FishNet.Object;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.FNet.Gameplay.Player
{
    public class PlayerMovementAuto : NetworkBehaviour
    {
        [SerializeField] private MovementType _movementType;

        private IVelocityProvider _velocityProvider;

        public override void OnStartClient()
        {
            AssignVelocityProvider();
        }

        private void AssignVelocityProvider()
        {
            _velocityProvider = MovementTypeConstructor.GetVelocityProvider(_movementType);
            _velocityProvider.InitDefault();
        }

        private void FixedUpdate()
        {
            if (!IsOwner) return;

            if (_movementType == MovementType.None) return;

            transform.position += _velocityProvider.GetVelocity(transform, Time.fixedDeltaTime);
        }
    }
}