namespace MauiFontFamily;

internal class PlatformFontFamilies : IPlatformFontFamilies
{
    readonly HashSet<string> fontFamilies;

    public PlatformFontFamilies()
    {
        try
        {
            fontFamilies = Tizen.UIExtensions.Common.FontLoader
                .GetFontFamilyNames()
                .OrderBy(x => x);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error getting Tizen font families: {ex.Message}");
            fontFamilies = [];
        }
    }

    public bool Exists(string familyName) => fontFamilies.Contains(familyName);

    public HashSet<string> FontFamilies() => fontFamilies;
}
