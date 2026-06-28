using CommunityToolkit.Mvvm.ComponentModel;
using DeviceSense.Core.Models.Peripherals;
using DeviceSense.Core.Services.Peripherals;
using System.Collections.ObjectModel;

namespace DeviceSense.UI.ViewModels.Peripherals
{
    public partial class DevicesViewModel : ObservableObject
    {
        private readonly DeviceListService _deviceListService;

        public ObservableCollection<DeviceInfo> Devices { get; } = new();

        public DevicesViewModel()
        {
            _deviceListService = new DeviceListService();
            LoadDevices();
        }

        private void LoadDevices()
        {
            var devices = _deviceListService.GetDevices();

            Devices.Clear();

            foreach (var device in devices)
            {
                Devices.Add(device);
            }
        }
    }
}