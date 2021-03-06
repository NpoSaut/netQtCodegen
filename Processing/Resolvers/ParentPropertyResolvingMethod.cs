﻿using System;
using System.Collections.Generic;

namespace Codegen.Processing.Resolvers
{
    /// <summary>Разрешает свойство через словарь свойств родительского элемента</summary>
    public class ParentPropertyResolvingMethod : IResolvingMethod
    {
        /// <summary>Разрешает значение свойства по его имени</summary>
        /// <param name="PropertyName">Название свойства</param>
        /// <param name="Arguments">Аргументы кодогенерации</param>
        /// <param name="Parameters"></param>
        public string Resolve(string PropertyName, GenerationArguments Arguments, IList<string> Parameters)
        {
            if (Arguments.ParentItem == null)
            {
                throw new ApplicationException(String.Format("Для элемента {0} не существует родительского элемента (возможно, это корневой элемент)",
                                                             Arguments.Item));
            }

            return Arguments.ParentItem.Properties[PropertyName];
        }
    }
}
