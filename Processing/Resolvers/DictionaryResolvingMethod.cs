using System.Collections.Generic;

namespace Codegen.Processing.Resolvers
{
    /// <summary>Находит значение свойства в словаре, который указывается при создании метода разрешения</summary>
    public class DictionaryResolvingMethod : IResolvingMethod
    {
        private readonly IDictionary<string, string> _dictionary;
        public DictionaryResolvingMethod(IDictionary<string, string> Dictionary) { _dictionary = Dictionary; }

        /// <summary>Разрешает значение свойства по его имени</summary>
        /// <param name="PropertyName">Название свойства</param>
        /// <param name="Arguments">Аргументы кодогенерации</param>
        public string Resolve(string PropertyName, GenerationArguments Arguments) { return _dictionary[PropertyName]; }
    }
}
