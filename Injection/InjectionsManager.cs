using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Codegen.Injection.ProcessingStates;

namespace Codegen.Injection
{
    public class InjectionsManager : IInjectionsManager
    {
        private readonly IDictionary<string, IDictionary<string, ICollection<string>>> _injections;

        public InjectionsManager() { _injections = new Dictionary<string, IDictionary<string, ICollection<string>>>(); }

        /// <summary>Вставляет кодовый фрагмент в указанный файл</summary>
        /// <param name="FileName">Имя файла</param>
        /// <param name="Anchor">Якорь для вставки кода</param>
        /// <param name="Injection">Фрагмент кода для вставки</param>
        public void Inject(string FileName, string Anchor, string Injection)
        {
            IDictionary<string, ICollection<string>> fileInjections = GetOrCreateFileInjections(FileName);
            ICollection<string> anchorInjections = GetOrCreateAnchorInjections(fileInjections, Anchor);
            anchorInjections.Add(Injection);
        }

        /// <summary>Заставляет менеджера фрагментов применить все указанные вставки во все файлы</summary>
        public void Apply()
        {
            foreach (var fileInjections in _injections)
            {
                if (!File.Exists(fileInjections.Key))
                    throw new FileNotFoundException("Не найден файл для инжектирования", fileInjections.Key);

                var stringBuilder = new StringBuilder();
                using (var sr = new StreamReader(fileInjections.Key))
                {
                    string line;
                    ILineProcessingState state = new ReadyForInjectionLineProcessingState(stringBuilder, fileInjections.Value);
                    while ((line = sr.ReadLine()) != null)
                        state = state.ProcessLine(line);
                }
                using (var fs = new StreamWriter(fileInjections.Key, false))
                {
                    fs.Write(stringBuilder.ToString());
                }
            }
        }

        private IDictionary<string, ICollection<string>> GetOrCreateFileInjections(string FileName)
        {
            IDictionary<string, ICollection<string>> value;
            if (!_injections.TryGetValue(FileName, out value))
            {
                value = new Dictionary<string, ICollection<string>>();
                _injections.Add(FileName, value);
            }
            return value;
        }

        private ICollection<string> GetOrCreateAnchorInjections(IDictionary<string, ICollection<string>> FileInjections, string AnchorName)
        {
            ICollection<string> value;
            if (!FileInjections.TryGetValue(AnchorName, out value))
            {
                value = new Collection<string>();
                FileInjections.Add(AnchorName, value);
            }
            return value;
        }
    }
}
