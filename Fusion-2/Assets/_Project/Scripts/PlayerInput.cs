using Fusion;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.Fusion2Net.Gameplay.Player
{
    public struct PlayerInput : INetworkInput
    {
        public Vector3 Movement;
    }
}