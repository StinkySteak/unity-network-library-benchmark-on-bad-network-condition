using Fusion;
using Fusion.Sockets;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.FusionNet
{
    public class NetworkRunnerCallbacksRegistrar : MonoBehaviour, INetworkRunnerCallbacks
    {
        [SerializeField] private EnhancedNetworkDebugStart _networkDebugStart;

        private void Start () 
        {
            _networkDebugStart.OnStartingGame += RegisterCallbacks;
        }

        public void RegisterCallbacks(NetworkRunner runner)
        {
            runner.AddCallbacks(this);
        }
        public void OnSceneLoadDone(NetworkRunner runner)
        {
            NetworkRunnerCallbacksMono[] callbacks = runner.SimulationUnityScene.FindObjectsOfTypeInOrder<NetworkRunnerCallbacksMono>();

            foreach (NetworkRunnerCallbacksMono callback in callbacks)
            {
                runner.AddCallbacks(callback);
                callback.AssignRunner(runner);
            }
        }

        public void OnConnectedToServer(NetworkRunner runner)
        {
        }

        public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
        {
        }

        public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
        {
        }

        public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
        {
        }

        public void OnDisconnectedFromServer(NetworkRunner runner)
        {
        }

        public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
        {
        }

        public void OnInput(NetworkRunner runner, NetworkInput input)
        {
        }

        public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
        {
        }

        public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
        {
        }

        public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
        {
        }

        public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
        {
        }


        public void OnSceneLoadStart(NetworkRunner runner)
        {
        }

        public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
        {
        }

        public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
        {
        }

        public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
        {
        }
    }
}