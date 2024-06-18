using FishNet.Object;
using StinkySteak.NetcodeLatency.Gameplay.Player;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.FNet.Gameplay.Player
{
    public class PlayerColorApplier : NetworkBehaviour
    {
        [SerializeField] private PlayerColor _colorApplier;

        private const int ACTIVE_PLAYER_REF = 1;

        private void FixedUpdate()
        {
            ApplyColor();
        }

        private void ApplyColor()
        {
            bool isLocal = IsOwner;
            bool isServer = IsServerInitialized;
            bool isProxy = !IsOwner && !IsServerInitialized;

            _colorApplier.ApplyColor(isLocal, isServer, isProxy);

            bool isVisible = OwnerId == ACTIVE_PLAYER_REF;

            _colorApplier.EnableRenderer(isVisible);
        }
    }
}