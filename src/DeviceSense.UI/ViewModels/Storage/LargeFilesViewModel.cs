using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DeviceSense.UI.ViewModels.Storage;

public record LargeFile(string Name, string Path, long SizeBytes);

public partial class LargeFilesViewModel : ObservableObject
{
    [ObservableProperty] private bool _isLoading;
    public ObservableCollection<LargeFile> Files { get; } = new();

    [RelayCommand]
    public async Task LoadAsync()
    {
        IsLoading = true;
        await Task.Run(() => { });
        IsLoading = false;
    }
}
