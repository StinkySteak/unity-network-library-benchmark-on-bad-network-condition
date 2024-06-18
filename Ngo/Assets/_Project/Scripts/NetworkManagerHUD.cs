using Unity.Netcode;
using UnityEngine;

namespace StinkySteak.NetcodeLatency.NGONet
{
    public class NetworkManagerHUD : MonoBehaviour
    {
        [SerializeField] private NetworkManager _networkManager;

        private void OnGUI()
        {
            if (_networkManager.IsListening)
            {
                return;
            }

            if (GUI.Button(new Rect(10, 10, 200, 50), "Run Server"))
            {
                _networkManager.StartServer();
            }

            if (GUI.Button(new Rect(10, 70, 200, 50), "Run Host"))
            {
                _networkManager.StartHost();
            }

            if (GUI.Button(new Rect(10, 70 + 60, 200, 50), "Run Client"))
            {
                _networkManager.StartClient();
            }
        }
    }
}