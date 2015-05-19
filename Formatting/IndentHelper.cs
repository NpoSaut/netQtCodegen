using System.Linq;

namespace Codegen.Formatting
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
            int indent = lines.Where(line => !string.IsNullOrWhiteSpace(line)).Select(line => line.MeasureIndent()).DefaultIfEmpty(0).Min();
            string res = string.Join("\n", lines.Select(line => line.Substring(indent)));
            return res;
        }

        /// <summary>Отступает каждую строку на указанное количество пробелов</summary>
        /// <param name="str">Несколько строк, которые нужно отступить</param>
        /// <param name="indent">Количество пробельных символов, на которые нужно отступить</param>
        /// <returns>Те же самые строки с указанным отступом</returns>
        public static string Indent(this string str, int indent)
        {
            var indention = new string(' ', indent);
            string[] lines = str.Split('\n');
            return string.Join("\n", lines.Select(line => indention + line));
        }
    }
}
