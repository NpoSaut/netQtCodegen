namespace Codegen.Injection
{
    /// <summary>Менеджер фрагментов кода</summary>
    public interface IInjectionsManager
    {
        /// <summary>Вставляет кодовый фрагмент в указанный файл</summary>
        /// <param name="FileName">Имя файла</param>
        /// <param name="Anchor">Якорь для вставки кода</param>
        /// <param name="Injection">Фрагмент кода для вставки</param>
        void Inject(string FileName, string Anchor, string Injection);

        /// <summary>Заставляет менеджера фрагментов применить все указанные вставки во все файлы</summary>
        void Apply();
    }
}
