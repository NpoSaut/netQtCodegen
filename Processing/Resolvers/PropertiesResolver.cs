using System.Collections.Generic;
using Codegen.ProjectEntities.Actions;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.Processing.Resolvers
{
    public class PropertiesResolver : IPropertiesResolver
    {
        private readonly IDictionary<string, IResolvingMethod> _resolvingMethods;

        public PropertiesResolver(IDictionary<string, IResolvingMethod> ResolvingMethods) { _resolvingMethods = ResolvingMethods; }

        /// <summary>��������� �������� �������� �� ��� �����</summary>
        /// <param name="PropertyName">��� ��������</param>
        /// <param name="PropertyNamespace">������������ ��� �������� (������� �����-������ �������� ����� '#')</param>
        /// <param name="Item">������� ��������� �������</param>
        /// <param name="InjectionTemplate">������ ������������� ����</param>
        /// <param name="InternalTemplates">������� ��� ��������� ���������� ���������</param>
        public string ResolvePropertyValue(string PropertyName, string PropertyNamespace, GenerationItem Item,
                                           string InjectionTemplate, IDictionary<string, string> InternalTemplates)
        {
            return _resolvingMethods[PropertyNamespace].Resolve(PropertyName, Item, InjectionTemplate, InternalTemplates);
        }
    }
}
