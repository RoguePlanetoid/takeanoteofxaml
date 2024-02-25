namespace MauiNotes.Controls;

/// <summary>
/// .NET MAUI Dialog
/// </summary>
/// <param name="application">Application</param>
public class MauiDialog(IApplicationProvider application)
{
    private const string delete_text = "Are you sure you want to Delete this Note?";

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="mainPage">Main Page</param>
    /// <param name="content">Dialog Content</param>
    /// <returns>True if Primary Button Selected False if Not</returns>
    public static async Task<bool> DeleteAsync(MainPage mainPage, DialogModel content) =>
        await mainPage.DisplayAlert(content.Title, delete_text, content.PrimaryOption, content.SecondaryOption);

    /// <summary>
    /// Upsert
    /// </summary>
    /// <param name="mainPage">Main Page</param>
    /// <param name="content">Dialog Content</param>
    /// <returns>Note if Primary Button Selected, Null if Not</returns>
    public async Task<bool> UpsertAsync(MainPage mainPage, DialogModel content)
    {
        var popup = new DialogPopup
        {
            BindingContext = content
        };
        var source = new CancellationTokenSource(TimeSpan.FromMinutes(2));
        var result = await mainPage.ShowPopupAsync(popup, source.Token);
        if(result is bool value && value)
        {
            application.Content.Note = content.Note;
            return true;
        }
        return false;
    }
}
