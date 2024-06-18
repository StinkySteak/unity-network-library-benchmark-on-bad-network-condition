using Mirror;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.MirrorNet.Gameplay.Player
{
    public class PlayerMovementAuto : NetworkBehaviour
    {
        [SerializeField] private MovementType _movementType;

        private IVelocityProvider _velocityProvider;

        public override void OnStartAuthority()
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
            if (!isOwned) return;

            if (_movementType == MovementType.None) return;

            transform.position += _velocityProvider.GetVelocity(transform, Time.fixedDeltaTime);
        }
    }
}