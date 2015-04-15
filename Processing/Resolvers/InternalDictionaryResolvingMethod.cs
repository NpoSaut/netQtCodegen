using System.Collections.Generic;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.Processing.Resolvers
{
    /// <summary>Находит значение во внутреннем словаре элемента генерации</summary>
    public class InternalDictionaryResolvingMethod : IResolvingMethod
    {
        public string Resolve(string PropertyName, GenerationItem Item, string InjectionTemplate, IDictionary<string, string> InternalTemplates)
        {
            return Item.Properties[PropertyName];
        }
    }
}
