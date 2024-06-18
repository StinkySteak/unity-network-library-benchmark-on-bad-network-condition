using Fusion;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.Fusion2Net
{
    public class NetworkedTransform : NetworkBehaviour, IBeforeTick, IAfterTick
    {
        [Networked] private Vector3 _position { get; set; }

        public override void Spawned()
        {
            Runner.SetIsSimulated(Object, true);
        }

        public void BeforeTick()
        {
            print("BeforeTick");
            transform.position = _position;
        }

        public void AfterTick()
        {
            _position = transform.position;
        }
    }
}