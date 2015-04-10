using System.Collections.Generic;

namespace QmlObjectPropertiesCodeGenerator.Processing
{
    /// <summary>Обработчик шаблонов кодогенерации</summary>
    public interface ITemplateProcessor
    {
        /// <summary>Обрабатывает шаблон и строит блок кода на его основе</summary>
        /// <param name="Template">Шаблон генерируемого кода</param>
        /// <param name="Properties">Словарь свойств для генерации кода</param>
        string ProcessTemplate(string Template, IDictionary<string, string> Properties);
    }
}
