namespace Codegen.Processing.SyntaxExtensions
{
    /// <summary>Делает первую букву строки строчной</summary>
    [ExtensionKey("first-small")]
    [ExtensionKey("first-lower")]
    public class FirstSmallSyntaxExtension : ISyntaxExtension
    {
        /// <summary>Применяет расширение к указанной строке</summary>
        /// <param name="str">Исходная строка</param>
        /// <returns>Модифицированная строка</returns>
        public string Apply(string str) { return str.ToFirstLower(); }
    }
}
