using Fusion;
using Fusion.Sockets;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.FusionNet.Gameplay.Player
{
    public class PlayerMovementAuto : NetworkBehaviour, INetworkRunnerCallbacks
    {
        [SerializeField] private MovementType _movementType;

        private IVelocityProvider _velocityProvider;

        public override void Spawned()
        {
            if (!HasInputAuthority) return;

            Runner.AddCallbacks(this);

            AssignVelocityProvider();
        }

        private void AssignVelocityProvider()
        {
            _velocityProvider = MovementTypeConstructor.GetVelocityProvider(_movementType);
            _velocityProvider.InitDefault();
        }

        public void OnInput(NetworkRunner runner, NetworkInput input)
        {
            if (!HasInputAuthority) return;

            if (_movementType == MovementType.None) return;

            PlayerInput playerInput = new();
            playerInput.Movement = _velocityProvider.GetVelocity(transform, Runner.DeltaTime);

            input.Set(playerInput);
        }


        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
        }

        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
        }

        public void OnConnectedToServer(NetworkRunner runner)
        {
        }

        public void OnDisconnectedFromServer(NetworkRunner runner)
        {
        }

        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {
        }

        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
        }

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
        }

        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {
        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
        }

        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
        {
        }

        public void OnSceneLoadDone(NetworkRunner runner)
        {
        }

        public void OnSceneLoadStart(NetworkRunner runner)
        {
        }
    }
}