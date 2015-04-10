using System.Collections.Generic;

namespace QmlObjectPropertiesCodeGenerator.ProjectEntities.Tasking
{
    /// <summary>Элемент генерации</summary>
    public class GenerationItem
    {
        public GenerationItem(IDictionary<string, string> Properties) { this.Properties = Properties; }

        /// <summary>Свойства элемента генерации</summary>
        /// <remarks>Словарь имя свойства -- значение свойства</remarks>
        public IDictionary<string, string> Properties { get; private set; }
    }
}
