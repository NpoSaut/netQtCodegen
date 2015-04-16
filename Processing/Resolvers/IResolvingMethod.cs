namespace Codegen.Processing.Resolvers
{
    /// <summary>Метод разрешения значения свойства</summary>
    public interface IResolvingMethod
    {
        /// <summary>Разрешает значение свойства по его имени</summary>
        /// <param name="PropertyName">Название свойства</param>
        /// <param name="Arguments">Аргументы кодогенерации</param>
        string Resolve(string PropertyName, GenerationArguments Arguments);
    }
}
