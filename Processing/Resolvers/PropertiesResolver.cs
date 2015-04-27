using System.Collections.Generic;

namespace Codegen.Processing.Resolvers
{
    public class PropertiesResolver : IPropertiesResolver
    {
        private readonly IDictionary<string, IResolvingMethod> _resolvingMethods;

        public PropertiesResolver(IDictionary<string, IResolvingMethod> ResolvingMethods) { _resolvingMethods = ResolvingMethods; }

        /// <summary>��������� �������� �������� �� ��� �����</summary>
        /// <param name="PropertyName">��� ��������</param>
        /// <param name="PropertyNamespace">������������ ��� �������� (������� ����� ��������)</param>
        /// <param name="Arguments">��������� �������������</param>
        /// <param name="Parameters"></param>
        public string ResolvePropertyValue(string PropertyName, string PropertyNamespace, GenerationArguments Arguments, IList<string> Parameters)
        {
            return _resolvingMethods[PropertyNamespace].Resolve(PropertyName, Arguments, Parameters);
        }
    }
}
