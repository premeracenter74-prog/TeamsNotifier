using System.Windows;
using TeamsNotifier.Services;

namespace TeamsNotifier;

public partial class MainWindow : Window
{
    private readonly ChromeService _chrome = new();

    public MainWindow()
    {
        InitializeComponent();

        Loaded += MainWindow_Loaded;
    }

    private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        var tab = await _chrome.FindTeamsTabAsync();

        if (tab == null)
        {
            MessageBox.Show("Teams не найден");
            return;
        }

        MessageBox.Show(tab.Title);
    }
}
