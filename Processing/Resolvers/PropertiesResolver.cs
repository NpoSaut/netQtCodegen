using System.Collections.Generic;

namespace Codegen.Processing.Resolvers
{
    public class PropertiesResolver : IPropertiesResolver
    {
        private readonly IDictionary<string, IResolvingMethod> _resolvingMethods;

        public PropertiesResolver(IDictionary<string, IResolvingMethod> ResolvingMethods) { _resolvingMethods = ResolvingMethods; }

        /// <summary>Вычисляет значение свойства по его имени</summary>
        /// <param name="PropertyName">Имя свойства</param>
        /// <param name="PropertyNamespace">Пространство имён свойства (задаётся перед символом)</param>
        /// <param name="Arguments">Аргументы кодогенерации</param>
        /// <param name="Parameters"></param>
        public string ResolvePropertyValue(string PropertyName, string PropertyNamespace, GenerationArguments Arguments, IList<string> Parameters)
        {
            return _resolvingMethods[PropertyNamespace].Resolve(PropertyName, Arguments, Parameters);
        }
    }
}
