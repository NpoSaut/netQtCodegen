using System.Collections.Generic;
using System.Linq;

namespace Codegen.ProjectEntities.Tasking
{
    /// <summary>Элемент генерации</summary>
    public class GenerationItem
    {
        public GenerationItem(string Name, IDictionary<string, string> Properties, IList<GenerationItem> Children)
        {
            this.Name = Name;
            this.Children = Children;
            this.Properties = Properties;
        }

        /// <summary>Свойства элемента генерации</summary>
        /// <remarks>Словарь имя свойства -- значение свойства</remarks>
        public IDictionary<string, string> Properties { get; private set; }

        /// <summary>Внутренние элементы генерации</summary>
        public IList<GenerationItem> Children { get; private set; }

        /// <summary>Имя элемента</summary>
        public string Name { get; private set; }

        public override string ToString() { return string.Join(", ", Properties.Select(pv => string.Format("{0}={1}", pv.Key, pv.Value))); }
    }
}
