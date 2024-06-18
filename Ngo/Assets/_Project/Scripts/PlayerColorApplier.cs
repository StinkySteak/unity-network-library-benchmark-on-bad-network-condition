using StinkySteak.NetcodeLatency.Gameplay.Player;
using Unity.Netcode;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.NGONet.Gameplay.Player
{
    public class PlayerColorApplier : NetworkBehaviour
    {
        [SerializeField] private PlayerColor _playerColor;

        private void FixedUpdate()
        {
            bool isLocal = IsOwner;
            bool isServer = IsServer;
            bool isProxy = !IsOwner || !IsServer;

            bool isVisible = OwnerClientId == 1;

            _playerColor.EnableRenderer(isVisible);
            _playerColor.ApplyColor(isLocal, isServer, isProxy);
        }
    }
}