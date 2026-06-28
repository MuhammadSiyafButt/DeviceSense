using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DeviceSense.UI.ViewModels.SystemHealth;

public record StartupApp(string Name, string Publisher, string Impact);

public partial class StartupViewModel : ObservableObject
{
    [ObservableProperty] private bool _isLoading;
    public ObservableCollection<StartupApp> Apps { get; } = new();

    [RelayCommand]
    public async Task LoadAsync()
    {
        IsLoading = true;
        await Task.Run(() => { });
        IsLoading = false;
    }
}
