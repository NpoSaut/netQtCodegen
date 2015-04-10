using System.Collections.Generic;
using System.Text;

namespace QmlObjectPropertiesCodeGenerator.Injection.ProcessingStates
{
    /// <summary>—осто€ние трансл€ции строк и ожидани€ нового €кор€</summary>
    internal class ReadyForInjectionLineProcessingState : LineProcessingStateBase
    {
        public ReadyForInjectionLineProcessingState(StringBuilder StringBuilder, IDictionary<string, ICollection<string>> Anchors)
            : base(StringBuilder, Anchors) { }

        public override ILineProcessingState ProcessLine(string line)
        {
            StringBuilder.AppendLine(line);
            string anchor = line.Trim();
            string l = string.Format(anchor, "start");

            if (!Anchors.ContainsKey(l)) return this;

            foreach (string injection in Anchors[l])
                StringBuilder.AppendLine(injection);

            return new WaitForAnchorEndLineProcessingState(StringBuilder, Anchors, string.Format(anchor, "end"));
        }
    }
}