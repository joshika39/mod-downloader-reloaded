using System.Globalization;
using System.Net.Mime;
using Avalonia.Markup.Xaml.Styling;

namespace Backend;

public class LocalizationService
{
    private readonly Dictionary<CultureInfo, ResourceInclude> _resourceDictionaries;
    private CultureInfo _currentCulture;

    public LocalizationService()
    {
        _resourceDictionaries = new Dictionary<CultureInfo, ResourceInclude>();
        _currentCulture = CultureInfo.CurrentCulture;
    }

    public void AddResourceDictionary(CultureInfo culture, ResourceInclude resourceDictionary)
    {
        _resourceDictionaries[culture] = resourceDictionary;
    }

    public void SetLanguage(CultureInfo culture)
    {
        if (_resourceDictionaries.TryGetValue(culture, out ResourceInclude resourceDictionary))
        {
            // MediaTypeNames.Application.Current.Resources.MergedDictionaries.Insert(0, resourceDictionary);
            _currentCulture = culture;
        }
    }

    public string GetLocalizedString(string key)
    {
        if (_resourceDictionaries.TryGetValue(_currentCulture, out ResourceInclude resourceDictionary))
        {
            // var localizedString = resourceDictionary.TryFindResource(key);
            // return localizedString?.ToString() ?? key;
        }

        return key;
    }
}