using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace DeviceSense.UI.ViewModels;

public partial class ChatViewModel : ObservableObject
{
    [ObservableProperty] private string _userInput = string.Empty;
    [ObservableProperty] private bool _isLoading;

    public ObservableCollection<string> Messages { get; } = new();

    [RelayCommand]
    public async Task SendAsync()
    {
        if (string.IsNullOrWhiteSpace(UserInput)) return;
        Messages.Add($"You: {UserInput}");
        UserInput = string.Empty;
        IsLoading = true;
        await Task.Delay(500);
        Messages.Add("AI: (response coming soon)");
        IsLoading = false;
    }
}
