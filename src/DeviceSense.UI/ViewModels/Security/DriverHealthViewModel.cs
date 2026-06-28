using CommunityToolkit.Mvvm.ComponentModel;
using DeviceSense.Core.Models.Security;
using DeviceSense.Core.Services.Security;
using System.Collections.ObjectModel;

namespace DeviceSense.UI.ViewModels.Security
{
    public partial class DriverHealthViewModel : ObservableObject
    {
        private readonly DriverHealthService _driverHealthService;

        public ObservableCollection<DriverInfo> Drivers { get; } = new();

        public DriverHealthViewModel()
        {
            _driverHealthService = new DriverHealthService();
            LoadDrivers();
        }

        private void LoadDrivers()
        {
            var drivers = _driverHealthService.GetDrivers();

            Drivers.Clear();

            foreach (var driver in drivers)
            {
                Drivers.Add(driver);
            }
        }
    }
}