using System.Collections.Generic;

namespace QmlObjectPropertiesCodeGenerator.Processing
{
    public class PropertiesResolver : IPropertiesResolver
    {
        private readonly IDictionary<string, IDictionary<string, string>> _globalDictionaries;

        public PropertiesResolver(IDictionary<string, string> GlobalProperties)
        {
            _globalDictionaries = new Dictionary<string, IDictionary<string, string>>
                                  {
                                      { "#", GlobalProperties }
                                  };
        }

        public string ResolvePropertyValue(string PropertyName, string PropertyNamespace, IDictionary<string, string> LocalProperties)
        {
            if (string.IsNullOrWhiteSpace(PropertyNamespace))
                return LocalProperties[PropertyName];
            return _globalDictionaries[PropertyNamespace][PropertyName];
        }
    }
}