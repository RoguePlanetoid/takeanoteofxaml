namespace MauiNotes;

/// <summary>
/// Application
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// Constructor
    /// </summary>
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}
