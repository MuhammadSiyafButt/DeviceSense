using System;

namespace DeviceSense.Core.Models.Network
{
    public class WifiInfo
    {
        public string Ssid { get; set; } = string.Empty;
        public bool IsConnected { get; set; }
        public int SignalStrengthPercent { get; set; }
        public string AuthenticationType { get; set; } = string.Empty;
        public string Band { get; set; } = string.Empty;   // "2.4 GHz" / "5 GHz"
        public double LinkSpeedMbps { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}