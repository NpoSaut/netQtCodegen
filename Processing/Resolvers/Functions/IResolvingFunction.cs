using System.Collections.Generic;

namespace Codegen.Processing.Resolvers.Functions
{
    public interface IResolvingFunction
    {
        string Execute(GenerationArguments Arguments, IList<string> Parameters);
    }
}
