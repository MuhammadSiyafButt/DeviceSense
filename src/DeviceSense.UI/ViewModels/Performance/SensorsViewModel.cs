using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DeviceSense.UI.ViewModels.Performance;

public record SensorReading(string Name, string Value, string Unit);

public partial class SensorsViewModel : ObservableObject
{
    [ObservableProperty] private bool _isLoading;
    public ObservableCollection<SensorReading> Sensors { get; } = new();

    [RelayCommand]
    public async Task LoadAsync()
    {
        IsLoading = true;
        await Task.Run(() => { });
        IsLoading = false;
    }
}
