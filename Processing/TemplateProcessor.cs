using System.Collections.Generic;

namespace QmlObjectPropertiesCodeGenerator.Processing
{
    public class TemplateProcessor : ITemplateProcessor
    {
        private IDictionary<string, string> _globalProperties;
        public TemplateProcessor(IDictionary<string, string> GlobalProperties) { _globalProperties = GlobalProperties; }

        /// <summary>Обрабатывает шаблон и строит блок кода на его основе</summary>
        /// <param name="Template">Шаблон генерируемого кода</param>
        /// <param name="Properties">Словарь свойств для генерации кода</param>
        public string ProcessTemplate(string Template, IDictionary<string, string> Properties) { }
    }
}
