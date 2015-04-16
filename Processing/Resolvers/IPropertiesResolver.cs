namespace Codegen.Processing.Resolvers
{
    /// <summary>Инструмент, разрешающий значения свойства по его имени</summary>
    public interface IPropertiesResolver
    {
        /// <summary>Вычисляет значение свойства по его имени</summary>
        /// <param name="PropertyName">Имя свойства</param>
        /// <param name="PropertyNamespace">Пространство имён свойства (задаётся перед символом)</param>
        /// <param name="Arguments">Аргументы кодогенерации</param>
        string ResolvePropertyValue(string PropertyName, string PropertyNamespace, GenerationArguments Arguments);
    }
}
