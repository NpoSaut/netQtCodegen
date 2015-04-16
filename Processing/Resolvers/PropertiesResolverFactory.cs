using System.Collections.Generic;

namespace Codegen.Processing.Resolvers
{
    public class PropertiesResolverFactory : IPropertiesResolverFactory
    {
        private readonly IDictionary<string, string> _globalProperties;
        public PropertiesResolverFactory(IDictionary<string, string> GlobalProperties) { _globalProperties = GlobalProperties; }

        public IPropertiesResolver GetPropertiesResolver(ITemplateProcessor TemplateProcessor)
        {
            return new PropertiesResolver(new Dictionary<string, IResolvingMethod>
                                          {
                                              { string.Empty, new InternalDictionaryResolvingMethod() },
                                              { "global", new DictionaryResolvingMethod(_globalProperties) },
                                              { "expand", new ExpandChildrenResolvingMethod(TemplateProcessor) },
                                              { "parent", new ParentPropertyResolvingMethod() }
                                          });
        }
    }
}
