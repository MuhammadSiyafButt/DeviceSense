using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeviceSense.Core.Models.Peripherals;
using DeviceSense.Core.Services.Peripherals;

namespace DeviceSense.UI.ViewModels.Peripherals;

public partial class DevicesViewModel : ObservableObject
{
    private readonly DeviceListService _deviceListService;

    [ObservableProperty]
    private ObservableCollection<DeviceInfo> _devices = new();

    [ObservableProperty]
    private bool _isLoading;

    public DevicesViewModel(DeviceListService deviceListService)
    {
        _deviceListService = deviceListService;
    }

    [RelayCommand]
    public async Task LoadAsync()
    {
        IsLoading = true;
        Devices.Clear();

        var result = await Task.Run(() => _deviceListService.GetDevices());

        foreach (var device in result)
            Devices.Add(device);

        IsLoading = false;
    }
}
