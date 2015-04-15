using System;

namespace Codegen.Processing.SyntaxExtensions
{
    /// <summary>Атрибут ключа расширения синтаксиса</summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ExtensionKeyAttribute : Attribute
    {
        public ExtensionKeyAttribute(string Key) { this.Key = Key; }

        /// <summary>Ключ расширения синтаксиса</summary>
        public String Key { get; private set; }
    }
}
