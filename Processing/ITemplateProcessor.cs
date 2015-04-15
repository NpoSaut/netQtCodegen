using System.Collections.Generic;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.Processing
{
    /// <summary>Обработчик шаблонов кодогенерации</summary>
    public interface ITemplateProcessor
    {
        /// <summary>Обрабатывает шаблон и строит блок кода на его основе</summary>
        /// <param name="Item">Словарь свойств для генерации кода</param>
        /// <param name="InjectionTemplate">Шаблон генерируемого кода</param>
        /// <param name="InternalTemplates">Шаблоны для генерации внутренних элементов</param>
        string ProcessInjectionTemplate(GenerationItem Item, string InjectionTemplate, IDictionary<string, string> InternalTemplates);
    }
}
