using Codegen.Processing.SyntaxExtensions;

namespace Codegen.Processing
{
    /// <summary>Менеджер расширений разметки</summary>
    public interface IExtensionsManager
    {
        /// <summary>Находит расширение по его ключу</summary>
        /// <param name="name">Ключ расширения</param>
        /// <returns>Расширение с указанным ключём</returns>
        /// <exception cref="ExtensionNotFoundException">Расширение с указанным ключём не было найдено в менеджере</exception>
        ISyntaxExtension this[string name] { get; }
    }
}
