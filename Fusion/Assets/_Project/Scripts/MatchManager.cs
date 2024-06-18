using UnityEngine;
using System.Collections.Generic;
using Fusion;

namespace StinkySteak.NetcodeLatency.FusionNet.Gameplay.Match
{
    public class MatchManager : NetworkRunnerCallbacksMono
    {
        [SerializeField] private NetworkObject _playerPrefab;
        [SerializeField] private Vector3 _position;

        private Dictionary<int, NetworkObject> _players = new Dictionary<int, NetworkObject>();

        public override void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
            var obj = runner.Spawn(_playerPrefab.gameObject, _position, Quaternion.identity, player);

            _players.Add(player.PlayerId, obj);
        }

        public override void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
            var obj = _players[player.PlayerId];

            runner.Despawn(obj);
        }
    }
}