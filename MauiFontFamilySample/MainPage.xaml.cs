using MauiFontFamily;

namespace MauiFontFamilySample;

public partial class MainPage : ContentPage
{
    readonly ISystemFontFamilyNames _systemFontFamilyNames;

    public MainPage(ISystemFontFamilyNames systemFontFamilyNames)
    {
        InitializeComponent();

        BindingContext = this;
        _systemFontFamilyNames = systemFontFamilyNames;
        CvListFontFamily.SelectionChanged += CvListFontFamily_SelectionChanged;
        CvListFontFamily.ItemsSource = _systemFontFamilyNames.GetSystemFontFamilyNames;
    }

    private void CvListFontFamily_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        EdTextSample.FontFamily = CvListFontFamily.SelectedItem as string;
    }
}
