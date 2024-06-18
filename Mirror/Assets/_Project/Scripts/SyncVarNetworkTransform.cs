using Mirror;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.MirrorNet
{
    public class SyncVarNetworkTransform : NetworkBehaviour
    {
        [SyncVar] private Vector3 _position;

        private void FixedUpdate()
        {
            if (isOwned)
                RPC_SetPosition(transform.position);
        }

        private void LateUpdate()
        {
            if (!isOwned)
                transform.position = _position;
        }

        [Command]
        private void RPC_SetPosition(Vector3 position)
        {
            _position = position;
        }
    }
}