using System;
using System.Runtime.Serialization;

namespace Codegen.Processing
{
    /// <Summary>Расширение с указанным названием не найдено в менеджере расширений</Summary>
    [Serializable]
    public class ExtensionNotFoundException : ApplicationException
    {
        public ExtensionNotFoundException(string ExtensionKey) : base(string.Format("Расширение \"{0}\" не найдено в менеджере расширений", ExtensionKey)) { }

        public ExtensionNotFoundException(string ExtensionKey, Exception inner)
            : base(string.Format("Расширение \"{0}\" не найдено в менеджере расширений", ExtensionKey), inner) { }

        protected ExtensionNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}
