using CommunityToolkit.Mvvm.ComponentModel;
using DeviceSense.Core.Models.Peripherals;
using DeviceSense.Core.Services.Peripherals;
using System.Collections.ObjectModel;

namespace DeviceSense.UI.ViewModels.Peripherals
{
    public partial class InstalledAppsViewModel : ObservableObject
    {
        private readonly InstalledAppsService _installedAppsService;

        public ObservableCollection<InstalledAppInfo> InstalledApps { get; } = new();

        public InstalledAppsViewModel()
        {
            _installedAppsService = new InstalledAppsService();
            LoadInstalledApps();
        }

        private void LoadInstalledApps()
        {
            var apps = _installedAppsService.GetInstalledApps();

            InstalledApps.Clear();

            foreach (var app in apps)
            {
                InstalledApps.Add(app);
            }
        }
    }
}