using Unity.Netcode;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.NGONet.Gameplay.Player
{
    public class PlayerMovementAuto : NetworkBehaviour
    {
        [SerializeField] private MovementType _movementType;

        private IVelocityProvider _velocityProvider;

        public override void OnNetworkSpawn()
        {
            if (!IsOwner) return;

            AssignVelocityProvider();
        }

        private void AssignVelocityProvider()
        {
            _velocityProvider = MovementTypeConstructor.GetVelocityProvider(_movementType);
            _velocityProvider.InitDefault();
        }

        private const int DEFAULT_PLAYER_REF = 1;


        private void FixedUpdate()
        {
            if (!IsOwner) return;

            if (_movementType == MovementType.None) return;

            if (OwnerClientId != DEFAULT_PLAYER_REF) return;

            transform.position += _velocityProvider.GetVelocity(transform, Time.fixedDeltaTime);
        }
    }
}