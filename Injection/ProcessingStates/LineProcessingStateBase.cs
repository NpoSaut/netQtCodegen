using System.Collections.Generic;
using System.Text;

namespace QmlObjectPropertiesCodeGenerator.Injection.ProcessingStates
{
    /// <summary>Базовый класс для состояния обработки строк</summary>
    internal abstract class LineProcessingStateBase : ILineProcessingState
    {
        protected readonly IDictionary<string, ICollection<string>> Anchors;
        protected readonly StringBuilder StringBuilder;

        public LineProcessingStateBase(StringBuilder StringBuilder, IDictionary<string, ICollection<string>> Anchors)
        {
            this.StringBuilder = StringBuilder;
            this.Anchors = Anchors;
        }

        public abstract ILineProcessingState ProcessLine(string line);
    }
}
