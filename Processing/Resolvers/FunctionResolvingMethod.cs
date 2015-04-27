using System.Collections.Generic;
using Codegen.Processing.Resolvers.Functions;

namespace Codegen.Processing.Resolvers
{
    public class FunctionResolvingMethod : IResolvingMethod
    {
        private readonly IDictionary<string, IResolvingFunction> _functions;

        public FunctionResolvingMethod(ITemplateProcessor TemplateProcessor)
        {
            _functions =
                new Dictionary<string, IResolvingFunction>
                {
                    { "expand", new ExpandFunction(TemplateProcessor) }
                };
        }

        /// <summary>Разрешает значение свойства по его имени</summary>
        /// <param name="PropertyName">Название свойства</param>
        /// <param name="Arguments">Аргументы кодогенерации</param>
        /// <param name="Parameters"></param>
        public string Resolve(string PropertyName, GenerationArguments Arguments, IList<string> Parameters)
        {
            IResolvingFunction function = _functions[PropertyName];
            return function.Execute(Arguments, Parameters);
        }
    }
}
