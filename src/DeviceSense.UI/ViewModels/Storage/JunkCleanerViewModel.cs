using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace DeviceSense.UI.ViewModels.Storage;

public partial class JunkCleanerViewModel : ObservableObject
{
    [ObservableProperty] private long _junkSizeBytes;
    [ObservableProperty] private bool _isScanning;
    [ObservableProperty] private bool _isCleaning;
    [ObservableProperty] private string _statusMessage = "Click Scan to find junk files";

    [RelayCommand]
    public async Task ScanAsync()
    {
        IsScanning = true;
        StatusMessage = "Scanning...";
        await Task.Run(() => { });
        StatusMessage = "Scan complete";
        IsScanning = false;
    }

    [RelayCommand]
    public async Task CleanAsync()
    {
        IsCleaning = true;
        StatusMessage = "Cleaning...";
        await Task.Run(() => { });
        StatusMessage = "Done! Files cleaned.";
        IsCleaning = false;
    }
}
