using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeviceSense.Core.Models.Security;
using DeviceSense.Core.Services.Security;

namespace DeviceSense.UI.ViewModels.Security;

public partial class DriverHealthViewModel : ObservableObject
{
    private readonly DriverHealthService _driverHealthService;

    [ObservableProperty]
    private ObservableCollection<DriverInfo> _drivers = new();

    [ObservableProperty]
    private bool _isLoading;

    public DriverHealthViewModel(DriverHealthService driverHealthService)
    {
        _driverHealthService = driverHealthService;
    }

    [RelayCommand]
    public async Task LoadAsync()
    {
        IsLoading = true;
        Drivers.Clear();

        var result = await Task.Run(() => _driverHealthService.GetDrivers());

        foreach (var driver in result)
            Drivers.Add(driver);

        IsLoading = false;
    }
}
