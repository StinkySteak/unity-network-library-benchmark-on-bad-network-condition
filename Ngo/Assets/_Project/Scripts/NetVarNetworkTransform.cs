using Unity.Netcode;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.NGONet
{
    public class NetVarNetworkTransform : NetworkBehaviour
    {
        private NetworkVariable<Vector3> _position = new NetworkVariable<Vector3>(writePerm: NetworkVariableWritePermission.Owner);

        private void FixedUpdate()
        {
            if (IsOwner)
                _position.Value = transform.position;
        }

        private void LateUpdate()
        {
            if (!IsOwner)
                transform.position = _position.Value;
        }
    }
}