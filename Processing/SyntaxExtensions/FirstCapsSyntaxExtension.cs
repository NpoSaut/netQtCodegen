namespace Codegen.Processing.SyntaxExtensions
{
    /// <summary>������ ������ ����� ������ ���������</summary>
    [ExtensionKey("first-caps")]
    [ExtensionKey("first-upper")]
    public class FirstCapsSyntaxExtension : ISyntaxExtension
    {
        /// <summary>��������� ���������� � ��������� ������</summary>
        /// <param name="str">�������� ������</param>
        /// <returns>���������������� ������</returns>
        public string Apply(string str) { return str.ToFirstUpper(); }
    }
}
