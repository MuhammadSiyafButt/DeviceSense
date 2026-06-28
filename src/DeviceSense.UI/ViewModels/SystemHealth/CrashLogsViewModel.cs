using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DeviceSense.UI.ViewModels.SystemHealth;

public record CrashLog(string Source, string Message, string DateTime);

public partial class CrashLogsViewModel : ObservableObject
{
    [ObservableProperty] private bool _isLoading;
    public ObservableCollection<CrashLog> Logs { get; } = new();

    [RelayCommand]
    public async Task LoadAsync()
    {
        IsLoading = true;
        await Task.Run(() => { });
        IsLoading = false;
    }
}
