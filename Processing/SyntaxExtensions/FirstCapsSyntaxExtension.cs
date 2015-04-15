namespace Codegen.Processing.SyntaxExtensions
{
    /// <summary>Делает первую букву строки заглавной</summary>
    [ExtensionKey("first-caps")]
    [ExtensionKey("first-upper")]
    public class FirstCapsSyntaxExtension : ISyntaxExtension
    {
        /// <summary>Применяет расширение к указанной строке</summary>
        /// <param name="str">Исходная строка</param>
        /// <returns>Модифицированная строка</returns>
        public string Apply(string str) { return str.ToFirstUpper(); }
    }
}
