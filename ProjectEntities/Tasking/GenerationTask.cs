using System.Collections.Generic;

namespace QmlObjectPropertiesCodeGenerator.ProjectEntities.Tasking
{
    /// <summary>Задача по генерации</summary>
    public class GenerationTask
    {
        public GenerationTask(IDictionary<string, string> Globals, ICollection<GenerationActionCalling> CallingActions, ICollection<GenerationItem> Items)
        {
            this.Globals = Globals;
            this.CallingActions = CallingActions;
            this.Items = Items;
        }

        /// <summary>Список вызываемых действий кодогенерации</summary>
        public ICollection<GenerationActionCalling> CallingActions { get; private set; }

        /// <summary>Глобальные переменные для этой задачи</summary>
        public IDictionary<string, string> Globals { get; private set; }

        /// <summary>Элементы генерации</summary>
        public ICollection<GenerationItem> Items { get; private set; }
    }
}
