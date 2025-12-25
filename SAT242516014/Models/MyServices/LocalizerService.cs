using Microsoft.Extensions.Localization;

namespace SAT242516014.Models.MyServices
{
    public class LocalizerService<TResource>
    {
        private readonly IStringLocalizer _localizer;

        public LocalizerService(IStringLocalizerFactory factory)
        {
            var assemblyName = typeof(TResource).Assembly.GetName().Name!;
            var resourceName = typeof(TResource).Name;

            _localizer = factory.Create(resourceName, assemblyName);
        }
        //dizinleyici (indexer)
        //this property (özellik)
        // public LocalizedString this[string key] => _localizer[key];
        public LocalizedString this[string key] => _localizer[key];

        public string Get(string key) => _localizer[key];

    }
}


