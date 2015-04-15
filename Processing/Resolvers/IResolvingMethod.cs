using System.Collections.Generic;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.Processing.Resolvers
{
    /// <summary>Метод разрешения значения свойства</summary>
    public interface IResolvingMethod
    {
        /// <summary>Разрешает значение свойства по его имени</summary>
        /// <param name="PropertyName">Название свойства</param>
        /// <param name="Item">Элемент генерации</param>
        /// <param name="InjectionTemplate">Шаблон генерируемого кода</param>
        /// <param name="InternalTemplates">Шаблоны для генерации внутренних элементов</param>
        string Resolve(string PropertyName, GenerationItem Item, string InjectionTemplate, IDictionary<string, string> InternalTemplates);
    }
}
