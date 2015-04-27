using System.Collections.Generic;

namespace Codegen.Processing.Resolvers
{
    /// <summary>Метод разрешения значения свойства</summary>
    public interface IResolvingMethod
    {
        /// <summary>Разрешает значение свойства по его имени</summary>
        /// <param name="PropertyName">Название свойства</param>
        /// <param name="Arguments">Аргументы кодогенерации</param>
        /// <param name="Parameters">Параметры вызова метода разрешения</param>
        string Resolve(string PropertyName, GenerationArguments Arguments, IList<string> Parameters);
    }
}
