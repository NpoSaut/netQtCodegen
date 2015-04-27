using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Codegen.Processing.Resolvers.Functions
{
    public abstract class ResolvingFunctionBase : IResolvingFunction
    {
        public string Execute(GenerationArguments Arguments, IList<string> Parameters)
        {
            var methodParameters = new Object[] { Arguments }.Concat(Parameters).ToArray();

            MethodInfo method = GetType().GetMethod("Execute", methodParameters.Select(p => p.GetType()).ToArray());

            return (string)method.Invoke(this, methodParameters);
        }
    }
}
