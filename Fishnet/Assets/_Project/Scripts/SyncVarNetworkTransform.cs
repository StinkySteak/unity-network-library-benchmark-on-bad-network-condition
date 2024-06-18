using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.FNet
{
    public class SyncVarNetworkTransform : NetworkBehaviour
    {
        private readonly SyncVar<Vector3> _position = new();

        public override void OnStartClient()
        {
            if (IsOwner)
                TimeManager.OnTick += OnTick;
        }

        private void OnTick()
        {
            RPC_SetPosition(transform.position);

        }

        private void LateUpdate()
        {
            if (!IsOwner)
                transform.position = _position.Value;
        }

        [ServerRpc]
        private void RPC_SetPosition(Vector3 position)
        {
            _position.Value = position;
        }
    }
}