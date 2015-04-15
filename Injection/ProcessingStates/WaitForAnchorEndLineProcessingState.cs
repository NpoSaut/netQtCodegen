using System.Collections.Generic;
using System.Text;

namespace Codegen.Injection.ProcessingStates
{
    /// <summary>Состояние ожидания конца текущего якоря</summary>
    internal class WaitForAnchorEndLineProcessingState : LineProcessingStateBase
    {
        private readonly string _waitFor;

        public WaitForAnchorEndLineProcessingState(StringBuilder StringBuilder, IDictionary<string, ICollection<string>> Anchors, string WaitFor)
            : base(StringBuilder, Anchors) { _waitFor = WaitFor; }

        public override ILineProcessingState ProcessLine(string line)
        {
            if (line.Contains(_waitFor))
            {
                StringBuilder.AppendLine(line);
                return new ReadyForInjectionLineProcessingState(StringBuilder, Anchors);
            }
            return this;
        }
    }
}
