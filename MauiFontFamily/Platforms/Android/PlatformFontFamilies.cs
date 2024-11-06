using Android.Runtime;

namespace MauiFontFamily;

internal class PlatformFontFamilies : IPlatformFontFamilies
{
    readonly HashSet<string> fontFamilies;

    public PlatformFontFamilies()
    {
        HashSet<string> fonts = [];
        try
        {
            var typeface = Java.Lang.Class.FromType(typeof(global::Android.Graphics.Typeface));
            var field = typeface.GetDeclaredField("sSystemFontMap");
            field.Accessible = true;
            var fontMap = field.Get(null).JavaCast<global::Android.Util.ArrayMap>();

            if (fontMap?.KeySet() is not null)
            {
                foreach (var key in fontMap.KeySet()!)
                {
                    if (!string.IsNullOrWhiteSpace(key?.ToString()))
                    {
                        fonts.Add(key.ToString()!);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error getting Android font families: {ex.Message}");
        }

        fontFamilies = fonts;
    }

    public bool Exists(string familyName) => fontFamilies.Contains(familyName);

    public HashSet<string> FontFamilies() => fontFamilies;
}
