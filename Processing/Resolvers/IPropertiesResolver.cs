using System.Collections.Generic;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.Processing.Resolvers
{
    /// <summary>����������, ����������� �������� �������� �� ��� �����</summary>
    public interface IPropertiesResolver
    {
        /// <summary>��������� �������� �������� �� ��� �����</summary>
        /// <param name="PropertyName">��� ��������</param>
        /// <param name="PropertyNamespace">������������ ��� �������� (������� �����-������ �������� ����� '#')</param>
        /// <param name="Item">������� ��������� �������</param>
        /// <param name="InjectionTemplate">������ ������������� ����</param>
        /// <param name="InternalTemplates">������� ��� ��������� ���������� ���������</param>
        string ResolvePropertyValue(string PropertyName, string PropertyNamespace, GenerationItem Item,
                                    string InjectionTemplate, IDictionary<string, string> InternalTemplates);
    }
}
