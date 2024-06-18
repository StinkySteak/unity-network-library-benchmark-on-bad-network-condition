using Netick.Unity;
using StinkySteak.NetcodeLatency.Gameplay.Player;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.NetickNet.Gameplay.Player
{
    public class PlayerColorApplier : NetworkBehaviour
    {
        [SerializeField] private PlayerColor _colorApplier;
        private const int ACTIVE_PLAYER_REF = 15;

        public override void NetworkRender()
        {
            DisableIrrelevantPlayers();
            ApplyColor();
        }

        private void DisableIrrelevantPlayers()
        {
            bool showObject = InputSourcePlayerId == ACTIVE_PLAYER_REF;

            _colorApplier.EnableRenderer(showObject);
        }

        private void ApplyColor()
        {
            bool isLocal = Sandbox.InputEnabled && IsInputSource;
            bool isServer = IsServer;
            bool isProxy = !Sandbox.InputEnabled && !IsServer;

            _colorApplier.ApplyColor(isLocal, isServer, isProxy);
        }
    }
}