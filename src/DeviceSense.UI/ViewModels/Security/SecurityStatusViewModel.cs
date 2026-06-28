using CommunityToolkit.Mvvm.ComponentModel;
using DeviceSense.Core.Models.Security;
using DeviceSense.Core.Services.Security;
using System.Threading.Tasks;

namespace DeviceSense.UI.ViewModels.Security
{
    public partial class SecurityStatusViewModel : ObservableObject
    {
        private readonly DefenderStatusService _defenderStatusService;

        private SecurityStatus? _securityStatus;
        public SecurityStatus? SecurityStatus
        {
            get => _securityStatus;
            set => SetProperty(ref _securityStatus, value);
        }

        public SecurityStatusViewModel()
        {
            _defenderStatusService = new DefenderStatusService();
            _ = LoadSecurityStatusAsync();
        }

        private async Task LoadSecurityStatusAsync()
        {
            SecurityStatus = await _defenderStatusService.GetStatusAsync();
        }
    }
}