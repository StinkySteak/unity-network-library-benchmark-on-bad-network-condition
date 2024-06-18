using Netick;
using Netick.Unity;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.NetickNet
{
    public class NetworkedTransform : NetworkBehaviour
    {
        [Networked] private Vector3 _position { get; set; }

        public override void NetcodeIntoGameEngine()
        {
            transform.position = _position;
        }
        public override void GameEngineIntoNetcode()
        {
            _position = transform.position;
        }
    }
}