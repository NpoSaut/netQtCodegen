using System.Collections.Generic;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.Processing
{
    /// <summary>Параметры генерирования</summary>
    public class GenerationArguments
    {
        /// <summary>Создаёт экземпляр параметров кодогенерации</summary>
        /// <param name="Item">Объект кодогенерации</param>
        /// <param name="Template">Шаблон кодогенерации</param>
        /// <param name="TemplatesDictionary">Дополнительные шаблоны кодогенерации</param>
        /// <param name="ParentItem">Родительский элемент</param>
        public GenerationArguments(GenerationItem Item, string Template, IDictionary<string, string> TemplatesDictionary, GenerationItem ParentItem = null)
        {
            this.ParentItem = ParentItem;
            this.Item = Item;
            this.Template = Template;
            this.TemplatesDictionary = TemplatesDictionary;
        }

        public GenerationItem ParentItem { get; private set; }

        /// <summary>Объект кодогенерации</summary>
        /// <remarks>На основе этого объекта будет сгенерирован код</remarks>
        public GenerationItem Item { get; private set; }

        /// <summary>Шаблон кодогенерации</summary>
        /// <remarks>По этому шаблону будет сгенерирован код</remarks>
        public string Template { get; private set; }

        /// <summary>Дополнительные шаблоны кодогенерации</summary>
        /// <remarks>Это шаблоны, которые будут использоваться в случае необходимости генерации кода для внутренних элементов</remarks>
        public IDictionary<string, string> TemplatesDictionary { get; private set; }
    }
}
