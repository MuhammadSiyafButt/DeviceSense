using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeviceSense.Core.Models.Peripherals;
using DeviceSense.Core.Services.Peripherals;

namespace DeviceSense.UI.ViewModels.Peripherals;

public partial class InstalledAppsViewModel : ObservableObject
{
    private readonly InstalledAppsService _installedAppsService;

    [ObservableProperty]
    private ObservableCollection<InstalledAppInfo> _apps = new();

    [ObservableProperty]
    private bool _isLoading;

    public InstalledAppsViewModel(InstalledAppsService installedAppsService)
    {
        _installedAppsService = installedAppsService;
    }

    [RelayCommand]
    public async Task LoadAsync()
    {
        IsLoading = true;
        Apps.Clear();

        var result = await Task.Run(() => _installedAppsService.GetInstalledApps());

        foreach (var app in result)
            Apps.Add(app);

        IsLoading = false;
    }
}
