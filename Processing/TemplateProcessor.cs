using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace QmlObjectPropertiesCodeGenerator.Processing
{
    public class TemplateProcessor : ITemplateProcessor
    {
        private readonly IExtensionsManager _extensions;
        private readonly IPropertiesResolver _propertiesResolver;

        public TemplateProcessor(IPropertiesResolver PropertiesResolver, IExtensionsManager Extensions)
        {
            _extensions = Extensions;
            _propertiesResolver = PropertiesResolver;
        }

        /// <summary>Обрабатывает шаблон и строит блок кода на его основе</summary>
        /// <param name="Template">Шаблон генерируемого кода</param>
        /// <param name="Properties">Словарь свойств для генерации кода</param>
        public string ProcessTemplate(string Template, IDictionary<string, string> Properties)
        {
            var regex = new Regex(@"\{(?<namespace>[#]?)(?<name>\w+)(:((?<extension>[\w-]+)\s?)+)?\}");
            return regex.Replace(Template, m => Evaluator(m, Properties));
        }

        private string Evaluator(Match match, IDictionary<string, string> Properties)
        {
            string propertyNamespace = match.Groups["namespace"].Value;
            string propertyName = match.Groups["name"].Value;
            List<string> extensions = match.Groups["extension"].Captures.OfType<Capture>().Select(c => c.Value).ToList();
            string propertyRawValue = _propertiesResolver.ResolvePropertyValue(propertyName, propertyNamespace, Properties);
            string propertyValue = _extensions.ApplyAll(propertyRawValue, extensions);

            return propertyValue;
        }
    }
}
