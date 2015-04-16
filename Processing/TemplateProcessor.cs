﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Codegen.Processing.Resolvers;

namespace Codegen.Processing
{
    public class TemplateProcessor : ITemplateProcessor
    {
        private readonly IExtensionsManager _extensions;
        private readonly IPropertiesResolver _propertiesResolver;

        public TemplateProcessor(PropertiesResolverFactory PropertiesResolverFactory, IExtensionsManager Extensions)
        {
            _propertiesResolver = PropertiesResolverFactory.GetPropertiesResolver(this);
            _extensions = Extensions;
        }

        /// <summary>Обрабатывает шаблон и строит блок кода на его основе</summary>
        /// <param name="Arguments">Аргументы генерации</param>
        public string ProcessInjectionTemplate(GenerationArguments Arguments)
        {
            int index;

            var regex = new Regex(@"\{((?<namespace>\w*)\@)?(?<name>\w+)(:((?<extension>[\w-]+)\s?)+)?\}");
            return regex.Replace(Arguments.Template,
                                 match =>
                                 {
                                     string propertyNamespace = match.Groups["namespace"].Value;
                                     string propertyName = match.Groups["name"].Value;
                                     List<string> extensions = match.Groups["extension"].Captures.OfType<Capture>().Select(c => c.Value).ToList();

                                     return EvaluteValue(propertyName, propertyNamespace, extensions, Arguments);
                                 });
        }

        private string EvaluteValue(string PropertyName, string PropertyNamespace, IEnumerable<string> Extensions, GenerationArguments Arguments)
        {
            string propertyRawValue = _propertiesResolver.ResolvePropertyValue(PropertyName, PropertyNamespace, Arguments);
            string propertyValue = _extensions.ApplyAll(propertyRawValue, Extensions);

            return propertyValue;
        }
    }
}
