using Mirror;
using StinkySteak.NetcodeLatency.Gameplay.Player;
using System.Collections.Generic;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.MirrorNet.Gameplay.Player
{
    public class PlayerColorApplier : NetworkBehaviour
    {
        [SerializeField] private PlayerColor _colorApplier;
        [SerializeField] private MeshRenderer _rendererLocal;
        private const int ACTIVE_PLAYER_REF = 1;

        private static List<PlayerColorApplier> _players = new();

        [SyncVar] private bool _isVisible;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void ClearGlobals()
        {
            _players?.Clear();
        }

        public override void OnStartServer()
        {
            if (_players.Count == 0)
                _isVisible = true;
            else
                _isVisible = false;

            _players.Add(this);
        }

        private void FixedUpdate()
        {
            ApplyColor();
        }

        private void ApplyColor()
        {
            bool isLocal = isOwned;
            bool isServer = base.isServer;
            bool isProxy = !isOwned && !base.isServer;

            _colorApplier.ApplyColor(isLocal, isServer, isProxy);
            _colorApplier.EnableRenderer(_isVisible);
        }
    }
}