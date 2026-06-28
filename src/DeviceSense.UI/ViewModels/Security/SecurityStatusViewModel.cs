using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DeviceSense.Core.Models.Security;
using DeviceSense.Core.Services.Security;

namespace DeviceSense.UI.ViewModels.Security;

public partial class SecurityStatusViewModel : ObservableObject
{
    private readonly DefenderStatusService _defenderStatusService;

    [ObservableProperty]
    private SecurityStatus? _security;

    [ObservableProperty]
    private bool _isLoading;

    public SecurityStatusViewModel(DefenderStatusService defenderStatusService)
    {
        _defenderStatusService = defenderStatusService;
    }

    [RelayCommand]
    public async Task LoadAsync()
    {
        IsLoading = true;

        Security = await _defenderStatusService.GetStatusAsync();

        IsLoading = false;
    }
}
