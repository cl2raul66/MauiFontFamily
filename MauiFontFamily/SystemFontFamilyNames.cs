namespace MauiFontFamily;

public interface ISystemFontFamilyNames
{
    IEnumerable<string> GetSystemFontFamilyNames { get; }
}

public class SystemFontFamilyNames : ISystemFontFamilyNames
{
    readonly IPlatformFontFamilies platformFontFamilies;

    public SystemFontFamilyNames()
    {
        platformFontFamilies = new PlatformFontFamilies();
    }

    public IEnumerable<string> GetSystemFontFamilyNames => platformFontFamilies.FontFamilies();
}
