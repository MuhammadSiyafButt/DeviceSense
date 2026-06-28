using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DeviceSense.UI.ViewModels.Storage;

public record DriveInfo(string Name, long TotalBytes, long FreeBytes);

public partial class StorageOverviewViewModel : ObservableObject
{
    [ObservableProperty] private bool _isLoading;
    public ObservableCollection<DriveInfo> Drives { get; } = new();

    [RelayCommand]
    public async Task LoadAsync()
    {
        IsLoading = true;
        await Task.Run(() => { });
        IsLoading = false;
    }
}
