using System;

namespace DeviceSense.Core.Models.Network
{
    public class BandwidthInfo
    {
        public string AdapterName { get; set; } = string.Empty;
        public double DownloadSpeedMbps { get; set; }
        public double UploadSpeedMbps { get; set; }
        public long TotalBytesReceived { get; set; }
        public long TotalBytesSent { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}