namespace Codegen.Processing.SyntaxExtensions
{
    /// <summary>������ ��� ����� ������ ����������</summary>
    [ExtensionKey("caps")]
    [ExtensionKey("upper")]
    [ExtensionKey("all-caps")]
    [ExtensionKey("all-upper")]
    public class AllCapsSyntaxExtension : ISyntaxExtension
    {
        /// <summary>��������� ���������� � ��������� ������</summary>
        /// <param name="str">�������� ������</param>
        /// <returns>���������������� ������</returns>
        public string Apply(string str) { return str.ToUpper(); }
    }
}
