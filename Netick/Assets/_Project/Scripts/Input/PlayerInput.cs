using Netick;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.NetickNet.Gameplay.Player
{
    public struct PlayerInput : INetworkInput
    {
        public Vector3 Movement;
    }
}