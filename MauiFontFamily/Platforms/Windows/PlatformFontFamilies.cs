using Microsoft.Graphics.Canvas.Text;

namespace MauiFontFamily;

internal class PlatformFontFamilies : IPlatformFontFamilies
{
    readonly HashSet<string> fontFamilies;

    public PlatformFontFamilies()
    {
        try
        {
            fontFamilies = [..CanvasTextFormat.GetSystemFontFamilies()];
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error getting Windows font families: {ex.Message}");
            fontFamilies = [];
        }
    }

    public bool Exists(string familyName) => fontFamilies.Contains(familyName);

    public HashSet<string> FontFamilies() => fontFamilies;
}
