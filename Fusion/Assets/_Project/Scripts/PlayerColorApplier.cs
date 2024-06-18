using Fusion;
using StinkySteak.NetcodeLatency.Gameplay.Player;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.FusionNet.Gameplay.Player
{
    public class PlayerColorApplier : NetworkBehaviour
    {
        [SerializeField] private PlayerColor _colorApplier;
        private const int ACTIVE_PLAYER_REF = 2;

        public override void Render()
        {
            DisableIrrelevantPlayers();
            ApplyColor();
        }

        private void DisableIrrelevantPlayers()
        {
            bool showObject = Object.InputAuthority.RawEncoded == ACTIVE_PLAYER_REF;

            _colorApplier.EnableRenderer(showObject);
        }

        private void ApplyColor()
        {
            bool isLocal = Runner.ProvideInput && HasInputAuthority;
            bool isServer = HasStateAuthority;
            bool isProxy = !Runner.ProvideInput && !HasStateAuthority;

            _colorApplier.ApplyColor(isLocal, isServer, isProxy);
        }
    }
}