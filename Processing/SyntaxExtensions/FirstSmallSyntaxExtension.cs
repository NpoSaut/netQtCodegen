namespace Codegen.Processing.SyntaxExtensions
{
    /// <summary>������ ������ ����� ������ ��������</summary>
    [ExtensionKey("first-small")]
    [ExtensionKey("first-lower")]
    public class FirstSmallSyntaxExtension : ISyntaxExtension
    {
        /// <summary>��������� ���������� � ��������� ������</summary>
        /// <param name="str">�������� ������</param>
        /// <returns>���������������� ������</returns>
        public string Apply(string str) { return str.ToFirstLower(); }
    }
}
