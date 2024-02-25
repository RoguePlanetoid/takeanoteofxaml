namespace XamlNotes.Models;

/// <summary>
/// Dialog Model
/// </summary>
public class DialogModel
{
    private const string red = "#ff4947";
    private const string orange = "#f57900";
    private const string yellow = "#ffc476";
    private const string green = "#6dc0a4";
    private const string blue = "#6f9acd";
    private const string indigo = "#833db8";
    private const string violet = "#c693c2";

    /// <summary>
    /// Title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Note
    /// </summary>
    public NoteModel Note { get; set; } = new();

    /// <summary>
    /// Primary Option
    /// </summary>
    public string PrimaryOption { get; set; } = string.Empty;

    /// <summary>
    /// Secondary Option
    /// </summary>
    public string SecondaryOption { get; set; } = string.Empty;

    /// <summary>
    /// Colours
    /// </summary>
    public List<string> Colours => [red, orange, yellow, green, blue, indigo, violet];
}
