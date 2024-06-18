using UnityEngine;

namespace StinkySteak.NetcodeLatency.FusionNet
{
    public class NetworkInfo : NetworkRunnerCallbacksMono
    {
        private void OnGUI()
        {
            if (Runner != null && Runner.IsConnectedToServer && Runner.ProvideInput)
            {
                Draw(0, "RTT", ((float)Runner.GetPlayerRtt(Runner.LocalPlayer) * 1000f).ToString(), "ms");
                Draw(1, "Delta time", (Time.deltaTime * 1000f).ToString(), "ms");
            }
        }

        private void Draw(int offset, string title, string content, string unit)
        {
            GUI.Label(new Rect(10, 10 + (15 * offset), 200, 50), $"{title}: ");
            GUI.Label(new Rect(130, 10 + (15 * offset), 200, 50), $"{content} {unit}");
        }
    }
}