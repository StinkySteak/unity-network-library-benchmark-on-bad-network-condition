using Fusion;
using Fusion.Sockets;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.FusionNet
{
    public class NetworkRunnerCallbacksMono : MonoBehaviour, INetworkRunnerCallbacks
    {
        protected NetworkRunner Runner;

        public void AssignRunner(NetworkRunner runner)
        {
            Runner = runner;
        }

        public virtual void OnConnectedToServer(NetworkRunner runner)
        {
        }

        public virtual void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
        }

        public virtual void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {
        }

        public virtual void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {
        }

        public virtual void OnDisconnectedFromServer(NetworkRunner runner)
        {
        }

        public virtual void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
        }

        public virtual void OnInput(NetworkRunner runner, NetworkInput input)
        {
        }

        public virtual void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
        }

        public virtual void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
        }

        public virtual void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
        }

        public virtual void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
        {
        }

        public virtual void OnSceneLoadDone(NetworkRunner runner)
        {
        }

        public virtual void OnSceneLoadStart(NetworkRunner runner)
        {
        }

        public virtual void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
        }

        public virtual void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
        }

        public virtual void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
        }
    }
}