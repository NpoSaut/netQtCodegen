using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Codegen.Processing.SyntaxExtensions;

namespace Codegen.Processing
{
    /// <summary>Менеджер расширений, который ищет расширения в текущей сборке при помощи рефлексии</summary>
    public class ReflectingExtensionsManager : IExtensionsManager
    {
        private readonly Dictionary<string, ISyntaxExtension> _extensions;

        public ReflectingExtensionsManager()
        {
            _extensions =
                Assembly.GetAssembly(typeof (ISyntaxExtension)).GetTypes()
                        .Where(t => typeof(ISyntaxExtension).IsAssignableFrom(t))
                        .SelectMany(t => t.GetCustomAttributes<ExtensionKeyAttribute>().Select(a => new { key = a.Key, type = t }))
                        .ToDictionary(x => x.key, x => (ISyntaxExtension)Activator.CreateInstance(x.type));
        }

        /// <summary>Находит расширение по его ключу</summary>
        /// <param name="name">Ключ расширения</param>
        /// <returns>Расширение с указанным ключём</returns>
        /// <exception cref="ExtensionNotFoundException">Расширение с указанным ключём не было найдено в менеджере</exception>
        public ISyntaxExtension this[string name]
        {
            get
            {
                ISyntaxExtension value;
                if (_extensions.TryGetValue(name, out value))
                    return value;
                throw new ExtensionNotFoundException(name);
            }
        }
    }
}