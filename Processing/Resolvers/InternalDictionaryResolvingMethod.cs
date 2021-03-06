﻿using System.Collections.Generic;

namespace Codegen.Processing.Resolvers
{
    /// <summary>Находит значение во внутреннем словаре элемента генерации</summary>
    public class InternalDictionaryResolvingMethod : IResolvingMethod
    {
        /// <summary>Разрешает значение свойства по его имени</summary>
        /// <param name="PropertyName">Название свойства</param>
        /// <param name="Arguments">Аргументы кодогенерации</param>
        /// <param name="Parameters"></param>
        public string Resolve(string PropertyName, GenerationArguments Arguments, IList<string> Parameters) { return Arguments.Item.Properties[PropertyName]; }
    }
}
