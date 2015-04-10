using System.Linq;

namespace QmlObjectPropertiesCodeGenerator.Formatting
{
    /// <summary>Утилиты для работы с отступами</summary>
    public static class IndentHelper
    {
        /// <summary>Измеряет отступ у указанной строки</summary>
        /// <param name="str">Одна строка с отступом</param>
        /// <returns>Количество пробелов в  начале строки</returns>
        public static int MeasureIndent(this string str) { return str.TakeWhile(c => c == ' ').Count(); }

        /// <summary>Обрезает отступ у всех линий, состоящих в указанной строке</summary>
        /// <param name="str">Несколько строк с отступами</param>
        /// <returns>Эти же строке с урезанными отступами</returns>
        /// <remarks>Разбивает сроку на линии, находит линию с минимальным отступом и обрезает все остальные под неё</remarks>
        public static string TrimIndents(this string str)
        {
            string[] lines = str.Split('\n');
            int indent = lines.Min(line => line.MeasureIndent());
            string res = string.Join("\n", lines.Select(line => line.Substring(indent)));
            return res;
        }
    }
}
