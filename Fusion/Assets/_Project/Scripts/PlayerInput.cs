using Fusion;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.FusionNet.Gameplay.Player
{
    public struct PlayerInput : INetworkInput
    {
        public Vector3 Movement;
    }
}