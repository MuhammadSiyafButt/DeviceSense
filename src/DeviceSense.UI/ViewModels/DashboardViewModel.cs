using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace DeviceSense.UI.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
    [ObservableProperty] private double _cpuUsage;
    [ObservableProperty] private double _ramUsage;
    [ObservableProperty] private int _batteryPercent;
    [ObservableProperty] private bool _isCharging;
    [ObservableProperty] private bool _isLoading;

    [RelayCommand]
    public async Task LoadAsync()
    {
        IsLoading = true;
        await Task.Delay(100); // placeholder until services are wired
        IsLoading = false;
    }
}
