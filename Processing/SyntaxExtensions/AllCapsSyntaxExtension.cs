namespace Codegen.Processing.SyntaxExtensions
{
    /// <summary>Делает все буквы строки заглавными</summary>
    [ExtensionKey("caps")]
    [ExtensionKey("upper")]
    [ExtensionKey("all-caps")]
    [ExtensionKey("all-upper")]
    public class AllCapsSyntaxExtension : ISyntaxExtension
    {
        /// <summary>Применяет расширение к указанной строке</summary>
        /// <param name="str">Исходная строка</param>
        /// <returns>Модифицированная строка</returns>
        public string Apply(string str) { return str.ToUpper(); }
    }
}
