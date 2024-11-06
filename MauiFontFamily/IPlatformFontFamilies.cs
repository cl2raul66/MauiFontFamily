namespace MauiFontFamily;

internal interface IPlatformFontFamilies
{
    HashSet<string> FontFamilies();
    bool Exists(string familyName);
}
