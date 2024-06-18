using Netick.Unity;
using Netick;
using UnityEngine;
using System.Collections.Generic;

namespace StinkySteak.Gameplay.Match
{
    public class MatchManager : NetworkEventsListener
    {
        [SerializeField] private NetworkObject _playerPrefab;
        [SerializeField] private Vector3 _position;

        private Dictionary<int, NetworkObject> _players = new Dictionary<int, NetworkObject>();

        public override void OnPlayerConnected(NetworkSandbox sandbox, Netick.NetworkPlayer player)
        {
            var obj = sandbox.NetworkInstantiate(_playerPrefab.gameObject, _position, Quaternion.identity, player);

            _players.Add(player.PlayerId, obj);
        }

        public override void OnPlayerDisconnected(NetworkSandbox sandbox, Netick.NetworkPlayer player, TransportDisconnectReason transportDisconnectReason)
        {
            var obj = _players[player.PlayerId];

            sandbox.Destroy(obj);
        }
    }
}