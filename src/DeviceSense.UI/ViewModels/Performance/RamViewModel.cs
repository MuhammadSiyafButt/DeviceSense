using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace DeviceSense.UI.ViewModels.Performance;

public partial class RamViewModel : ObservableObject
{
    [ObservableProperty] private double _usagePercent;
    [ObservableProperty] private long _usedBytes;
    [ObservableProperty] private long _totalCapacityBytes;
    [ObservableProperty] private bool _isLoading;

    [RelayCommand]
    public async Task LoadAsync()
    {
        IsLoading = true;
        await Task.Run(() => { });
        IsLoading = false;
    }
}
