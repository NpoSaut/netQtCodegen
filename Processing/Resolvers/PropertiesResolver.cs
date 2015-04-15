using System.Collections.Generic;
using Codegen.ProjectEntities.Actions;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.Processing.Resolvers
{
    public class PropertiesResolver : IPropertiesResolver
    {
        private readonly IDictionary<string, IResolvingMethod> _resolvingMethods;

        public PropertiesResolver(IDictionary<string, IResolvingMethod> ResolvingMethods) { _resolvingMethods = ResolvingMethods; }

        /// <summary>Вычисляет значение свойства по его имени</summary>
        /// <param name="PropertyName">Имя свойства</param>
        /// <param name="PropertyNamespace">Пространство имён свойства (задаётся каким-нибудь символом вроде '#')</param>
        /// <param name="Item">Словарь локальных свойств</param>
        /// <param name="InjectionTemplate">Шаблон генерируемого кода</param>
        /// <param name="InternalTemplates">Шаблоны для генерации внутренних элементов</param>
        public string ResolvePropertyValue(string PropertyName, string PropertyNamespace, GenerationItem Item,
                                           string InjectionTemplate, IDictionary<string, string> InternalTemplates)
        {
            return _resolvingMethods[PropertyNamespace].Resolve(PropertyName, Item, InjectionTemplate, InternalTemplates);
        }
    }
}
