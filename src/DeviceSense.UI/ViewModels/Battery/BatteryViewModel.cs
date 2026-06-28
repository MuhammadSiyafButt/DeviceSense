using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace DeviceSense.UI.ViewModels.Battery;

public partial class BatteryViewModel : ObservableObject
{
    [ObservableProperty] private int _chargePercent;
    [ObservableProperty] private bool _isCharging;
    [ObservableProperty] private string _status = string.Empty;
    [ObservableProperty] private bool _isLoading;

    [RelayCommand]
    public async Task LoadAsync()
    {
        IsLoading = true;
        await Task.Run(() =>
        {
            // DeviceSense.Core.Services.Battery.BatteryService will be called here
        });
        IsLoading = false;
    }
}
