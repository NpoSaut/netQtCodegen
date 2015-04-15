using System.Collections.Generic;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.Processing.Resolvers
{
    /// <summary>Инструмент, разрешающий значения свойства по его имени</summary>
    public interface IPropertiesResolver
    {
        /// <summary>Вычисляет значение свойства по его имени</summary>
        /// <param name="PropertyName">Имя свойства</param>
        /// <param name="PropertyNamespace">Пространство имён свойства (задаётся каким-нибудь символом вроде '#')</param>
        /// <param name="Item">Словарь локальных свойств</param>
        /// <param name="InjectionTemplate">Шаблон генерируемого кода</param>
        /// <param name="InternalTemplates">Шаблоны для генерации внутренних элементов</param>
        string ResolvePropertyValue(string PropertyName, string PropertyNamespace, GenerationItem Item,
                                    string InjectionTemplate, IDictionary<string, string> InternalTemplates);
    }
}
