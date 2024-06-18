using UnityEngine;

namespace StinkySteak.NetcodeLatency.Fusion2Net
{
    public class NetworkInfo : NetworkRunnerCallbacksMono
    {
        private void OnGUI()
        {
            if (Runner != null && Runner.IsConnectedToServer && Runner.ProvideInput)
            {
                Draw(0, "RTT", (Runner.GetPlayerRtt(Runner.LocalPlayer) * 1000f).ToString(), "ms");
                //Draw(3, "Interp Delay", (Runner..InterpolationDelay * 1000f).ToString(), "ms");
                // Draw(4, "Resims", Runner.IsResimulation.Resimulations.Average.ToString(), "Ticks");
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