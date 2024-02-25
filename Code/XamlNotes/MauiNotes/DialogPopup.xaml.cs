namespace MauiNotes;

/// <summary>
/// Dialog Popup
/// </summary>
public partial class DialogPopup : Popup
{
    /// <summary>
    /// Constructor
    /// </summary>
    public DialogPopup() => 
        InitializeComponent();

    /// <summary>
    /// Primary Option
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">Event</param>
    private async void PrimaryOption(object sender, EventArgs e) => await CloseAsync(true);

    /// <summary>
    /// Secondary Option
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">Event</param>
    private async void SecondaryOption(object sender, EventArgs e) => await CloseAsync(false);
}