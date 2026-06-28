using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DeviceSense.UI.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private object? _currentView;

    public MainViewModel()
    {
        NavigateTo("Dashboard");
    }

    [RelayCommand]
    private void Navigate(string destination)
    {
        NavigateTo(destination);
    }

    private void NavigateTo(string destination)
    {
        CurrentView = destination switch
        {
            "Dashboard" => new Views.DashboardView(),
            "Performance" => new Views.Performance.CpuView(),
            "Storage" => new Views.Storage.StorageOverviewView(),
            "Battery" => new Views.Battery.BatteryView(),
            "Devices" => new Views.Peripherals.DevicesView(),
            "InstalledApps" => new Views.Peripherals.InstalledAppsView(),
            "SecurityStatus" => new Views.Security.SecurityStatusView(),
            "DriverHealth" => new Views.Security.DriverHealthView(),
            "Wifi" => new Views.Network.WifiSignalView(),
            "Bandwidth" => new Views.Network.BandwidthView(),
            "Startup" => new Views.SystemHealth.StartupView(),
            "Updates" => new Views.SystemHealth.UpdatesView(),
            "CrashLogs" => new Views.SystemHealth.CrashLogsView(),
            "Chat" => new Views.ChatView(),
            _ => new Views.DashboardView()
        };
    }
}