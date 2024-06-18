using Unity.Netcode.Components;

namespace StinkySteak.NetcodeLatency.NGONet
{
    public class ClientNetworkTransform : NetworkTransform
    {
        protected override bool OnIsServerAuthoritative()
        {
            return false;
        }
    }
}