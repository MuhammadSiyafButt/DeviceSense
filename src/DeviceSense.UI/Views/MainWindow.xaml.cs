using System.Windows;
using DeviceSense.UI.ViewModels;

namespace DeviceSense.UI;

public partial class MainWindow : Window
{
    private readonly MainViewModel _vm;

    public MainWindow()
    {
        InitializeComponent();
        _vm = new MainViewModel();
        DataContext = _vm;
    }
}