using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace QmlObjectPropertiesCodeGenerator.Processing
{
    public class TemplateProcessor : ITemplateProcessor
    {
        private IDictionary<string, string> _globalProperties;
        public TemplateProcessor(IDictionary<string, string> GlobalProperties) { _globalProperties = GlobalProperties; }

        /// <summary>Обрабатывает шаблон и строит блок кода на его основе</summary>
        /// <param name="Template">Шаблон генерируемого кода</param>
        /// <param name="Properties">Словарь свойств для генерации кода</param>
        public string ProcessTemplate(string Template, IDictionary<string, string> Properties)
        {
            Regex regex = new Regex(@"\{(?<name>\w+)(:((?<extension>[\w-]+)\s?)+)?\}");
            var matches = regex.Matches(Template);

            foreach (var match in matches.OfType<Match>())
            {
                var name = match.Groups["name"].Value;
                var extensions = match.Groups["extension"].Captures.OfType<Capture>().Select(c => c.Value).ToList();
            }

            return null;
        }
    }
}
