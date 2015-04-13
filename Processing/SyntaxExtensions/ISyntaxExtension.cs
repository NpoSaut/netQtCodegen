namespace QmlObjectPropertiesCodeGenerator.Processing.SyntaxExtensions
{
    /// <summary>Расширение разметки</summary>
    public interface ISyntaxExtension
    {
        /// <summary>Применяет расширение к указанной строке</summary>
        /// <param name="str">Исходная строка</param>
        /// <returns>Модифицированная строка</returns>
        string Apply(string str);
    }
}
