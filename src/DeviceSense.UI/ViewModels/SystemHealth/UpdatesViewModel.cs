using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DeviceSense.UI.ViewModels.SystemHealth;

public record WindowsUpdate(string Title, string Description, string Date);

public partial class UpdatesViewModel : ObservableObject
{
    [ObservableProperty] private bool _isLoading;
    public ObservableCollection<WindowsUpdate> Updates { get; } = new();

    [RelayCommand]
    public async Task LoadAsync()
    {
        IsLoading = true;
        await Task.Run(() => { });
        IsLoading = false;
    }
}
