namespace MauiNotes.Controls;

/// <summary>
/// Note Control
/// </summary>
public class NoteControl : Grid
{
    private const string note_path = "M 0,233.33333 V 0 H 233.33333 466.66666 V 183.69805 367.3961 l -57.66667,49.60273 -57.66666,49.60274 -175.66667,0.0325 L 0,466.66666 Z";
    private const string corner_path = "m 351.70982,366.69855 114.94703,0.77358 -115.33333,99.12108 z";
    private const string note_font = "Calligraffitti";
    private const int note_size = 466;

    internal Grid _grid;

    /// <summary>
    /// Get Path
    /// </summary>
    /// <param name="value">String</param>
    /// <returns>Path</returns>
    private static Path GetPath(string value) => 
        new Path().LoadFromXaml(
        @$"<Path xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>
            <Path.Data>{value}</Path.Data>
        </Path>");

    /// <summary>
    /// Layout
    /// </summary>
    private void Layout()
    {
        var path = GetPath(note_path);
        path.WidthRequest = note_size;
        path.HeightRequest = note_size;
        path.SetBinding(Shape.FillProperty, new Binding()
        {
            Mode = BindingMode.TwoWay,
            Path = nameof(Fill),
            Source = this
        });
        var corner = GetPath(corner_path);
        corner.WidthRequest = note_size;
        corner.HeightRequest = note_size;
        corner.Fill = Color.FromRgba(255, 255, 255, 80);
        var note = new Grid()
        {
            HeightRequest = note_size,
            WidthRequest = note_size
        };
        
        note.Children.Add(path);
        note.Children.Add(corner);
        note.SetValue(RowSpanProperty, 2);
        _grid.Children.Add(note);

        var rectangle = new Rectangle()
        {
            Fill = Color.FromRgba(0, 0, 0, 40),
            Aspect = Stretch.UniformToFill,
            WidthRequest = note_size
        };
        rectangle.SetValue(RowProperty, 0);
        _grid.Children.Add(rectangle);
        var title = new Label()
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(2),
            FontFamily = note_font,
            FontSize = 34
        };
        title.SetBinding(Label.TextProperty, new Binding()
        {
            Mode = BindingMode.TwoWay,
            Path = nameof(Title),
            Source = this
        });
        title.SetValue(RowProperty, 0);
        _grid.Children.Add(title);
        var content = new Label()
        {
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Start,
            Margin = new Thickness(5),
            FontFamily = note_font,
            FontSize = 30
        };
        content.SetBinding(Label.TextProperty, new Binding()
        {
            Mode = BindingMode.TwoWay,
            Path = nameof(Content),
            Source = this
        });
        content.SetValue(RowProperty, 1);
        _grid.Children.Add(content);
    }

    /// <summary>
    /// Title Property
    /// </summary>
    public static readonly BindableProperty TitleProperty = 
        BindableProperty.Create(nameof(Title), typeof(string), typeof(NoteControl), null);

    /// <summary>
    /// Content Property
    /// </summary>
    public static readonly BindableProperty ContentProperty =
        BindableProperty.Create(nameof(Content), typeof(string), typeof(NoteControl), null);

    /// <summary>
    /// Fill Property
    /// </summary>
    public static readonly BindableProperty FillProperty =
        BindableProperty.Create(nameof(Fill), typeof(Brush), typeof(NoteControl), 
        new SolidColorBrush(Colors.Transparent));

    /// <summary>
    /// Title
    /// </summary>
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    /// <summary>
    /// Content
    /// </summary>
    public string Content
    {
        get => (string)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    /// <summary>
    /// Fill
    /// </summary>
    public Brush Fill
    {
        get => (Brush)GetValue(FillProperty);
        set => SetValue(FillProperty, value);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public NoteControl()
    {
        _grid = new Grid()
        {
            HeightRequest = note_size,
            WidthRequest = note_size
        };
        _grid.RowDefinitions.Add(new RowDefinition(new GridLength(0.15, GridUnitType.Star)));
        _grid.RowDefinitions.Add(new RowDefinition(new GridLength(0.85, GridUnitType.Star)));
        Layout();
        Children.Add(_grid);
    }
}
