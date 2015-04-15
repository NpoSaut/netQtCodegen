using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Codegen.Processing.Resolvers;
using Codegen.ProjectEntities.Actions;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.Processing
{
    public class TemplateProcessor : ITemplateProcessor
    {
        private readonly IPropertiesResolver _propertiesResolver;
        private readonly IExtensionsManager _extensions;

        public TemplateProcessor(PropertiesResolverFactory PropertiesResolverFactory, IExtensionsManager Extensions)
        {
            _propertiesResolver = PropertiesResolverFactory.GetPropertiesResolver(this);
            _extensions = Extensions;
        }

        /// <summary>Обрабатывает шаблон и строит блок кода на его основе</summary>
        /// <param name="Item">Словарь свойств для генерации кода</param>
        /// <param name="InjectionTemplate">Шаблон генерируемого кода</param>
        /// <param name="InternalTemplates">Шаблоны для генерации внутренних элементов</param>
        public string ProcessInjectionTemplate(GenerationItem Item, string InjectionTemplate, IDictionary<string, string> InternalTemplates)
        {
            var regex = new Regex(@"\{((?<namespace>\w*)\@)?(?<name>\w+)(:((?<extension>[\w-]+)\s?)+)?\}");
            return regex.Replace(InjectionTemplate, m => Evaluator(m, Item, InjectionTemplate, InternalTemplates));
        }

        private string Evaluator(Match match, GenerationItem Item, string InjectionTemplate, IDictionary<string, string> InternalTemplates)
        {
            string propertyNamespace = match.Groups["namespace"].Value;
            string propertyName = match.Groups["name"].Value;
            List<string> extensions = match.Groups["extension"].Captures.OfType<Capture>().Select(c => c.Value).ToList();

            string propertyRawValue = _propertiesResolver.ResolvePropertyValue(propertyName, propertyNamespace, Item, InjectionTemplate, InternalTemplates);
            string propertyValue = _extensions.ApplyAll(propertyRawValue, extensions);

            return propertyValue;
        }
    }
}
