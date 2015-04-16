namespace Codegen.Processing.Resolvers
{
    /// <summary>����������, ����������� �������� �������� �� ��� �����</summary>
    public interface IPropertiesResolver
    {
        /// <summary>��������� �������� �������� �� ��� �����</summary>
        /// <param name="PropertyName">��� ��������</param>
        /// <param name="PropertyNamespace">������������ ��� �������� (������� ����� ��������)</param>
        /// <param name="Arguments">��������� �������������</param>
        string ResolvePropertyValue(string PropertyName, string PropertyNamespace, GenerationArguments Arguments);
    }
}
