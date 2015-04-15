using System.Collections.Generic;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.Processing.Resolvers
{
    /// <summary>Находит значение свойства в словаре, который указывается при создании метода разрешения</summary>
    public class DictionaryResolvingMethod : IResolvingMethod
    {
        private readonly IDictionary<string, string> _dictionary;
        public DictionaryResolvingMethod(IDictionary<string, string> Dictionary) { _dictionary = Dictionary; }

        public string Resolve(string PropertyName, GenerationItem Item, string InjectionTemplate, IDictionary<string, string> InternalTemplates)
        {
            return _dictionary[PropertyName];
        }
    }
}
