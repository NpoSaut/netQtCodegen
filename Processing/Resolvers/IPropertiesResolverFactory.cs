using System.Collections.Generic;

namespace Codegen.Processing.Resolvers
{
    public interface IPropertiesResolverFactory
    {
        IPropertiesResolver GetPropertiesResolver(ITemplateProcessor TemplateProcessor);
    }
}
