using Fusion;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.FusionNet
{
    public class NetworkedTransform : NetworkBehaviour, IBeforeTick, IAfterTick
    {
        [Networked] private Vector3 _position { get; set; }

        public void BeforeTick()
        {
            transform.position = _position;
        }

        public void AfterTick()
        {
            _position = transform.position;
        }
    }
}