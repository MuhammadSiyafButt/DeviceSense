using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace DeviceSense.UI.ViewModels.Network;

public partial class WifiSignalViewModel : ObservableObject
{
    [ObservableProperty] private string _ssid = string.Empty;
    [ObservableProperty] private int _signalStrength;
    [ObservableProperty] private string _ipAddress = string.Empty;
    [ObservableProperty] private bool _isConnected;
    [ObservableProperty] private bool _isLoading;

    [RelayCommand]
    public async Task LoadAsync()
    {
        IsLoading = true;
        await Task.Run(() => { });
        IsLoading = false;
    }
}
