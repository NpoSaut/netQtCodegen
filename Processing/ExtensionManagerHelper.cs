using System;
using System.Collections.Generic;
using System.Linq;

namespace Codegen.Processing
{
    /// <summary>Класс утилит для более удобного использования менеджера расширений</summary>
    public static class ExtensionManagerHelper
    {
        /// <summary>Последовательно применяет все расширения из списка указанной строке</summary>
        /// <param name="Manager">Менеджер расширений</param>
        /// <param name="Str">Исходная строка</param>
        /// <param name="ExtensionKeys">Список ключей расширений</param>
        /// <returns>Строка после применения всех расширений</returns>
        public static string ApplyAll(this IExtensionsManager Manager, String Str, IEnumerable<string> ExtensionKeys)
        {
            return ExtensionKeys.Aggregate(Str, (agr, extension) => Manager[extension].Apply(agr));
        }
    }
}