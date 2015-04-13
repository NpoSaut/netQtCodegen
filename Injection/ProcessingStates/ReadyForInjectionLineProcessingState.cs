using System.Collections.Generic;
using System.Linq;
using System.Text;
using QmlObjectPropertiesCodeGenerator.Formatting;

namespace QmlObjectPropertiesCodeGenerator.Injection.ProcessingStates
{
    /// <summary>—осто€ние трансл€ции строк и ожидани€ нового €кор€</summary>
    internal class ReadyForInjectionLineProcessingState : LineProcessingStateBase
    {
        private readonly IDictionary<string, string> _startAnchors;

        public ReadyForInjectionLineProcessingState(StringBuilder StringBuilder, IDictionary<string, ICollection<string>> Anchors)
            : base(StringBuilder, Anchors) { _startAnchors = Anchors.Keys.ToDictionary(a => string.Format(a, "start")); }

        public override ILineProcessingState ProcessLine(string line)
        {
            StringBuilder.AppendLine(line);
            string anchor = line.Trim();

            if (!_startAnchors.ContainsKey(anchor)) return this;

            foreach (string injection in Anchors[_startAnchors[anchor]])
                StringBuilder.AppendLine(injection.Indent(line.MeasureIndent()));

            return new WaitForAnchorEndLineProcessingState(StringBuilder, Anchors, string.Format(_startAnchors[anchor], "end"));
        }
    }
}
