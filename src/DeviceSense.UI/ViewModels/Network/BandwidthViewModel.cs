using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace DeviceSense.UI.ViewModels.Network;

public partial class BandwidthViewModel : ObservableObject
{
    [ObservableProperty] private double _downloadMbps;
    [ObservableProperty] private double _uploadMbps;
    [ObservableProperty] private bool _isLoading;

    [RelayCommand]
    public async Task LoadAsync()
    {
        IsLoading = true;
        await Task.Run(() => { });
        IsLoading = false;
    }
}
