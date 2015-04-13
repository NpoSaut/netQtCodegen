using System.Collections.Generic;

namespace QmlObjectPropertiesCodeGenerator.Processing
{
    /// <summary>����������, ����������� �������� �������� �� ��� �����</summary>
    public interface IPropertiesResolver
    {
        /// <summary>��������� �������� �������� �� ��� �����</summary>
        /// <param name="PropertyName">��� ��������</param>
        /// <param name="PropertyNamespace">������������ ��� �������� (������� �����-������ �������� ����� '#')</param>
        /// <param name="LocalProperties">������� ��������� �������</param>
        string ResolvePropertyValue(string PropertyName, string PropertyNamespace, IDictionary<string, string> LocalProperties);
    }
}
