using System.Collections.Generic;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.Processing
{
    /// <summary>Менеджер действий по кодогенерации</summary>
    public interface IActionsManager
    {
        /// <summary>Запускает действие по кодогенерации</summary>
        /// <param name="ActionName">Название действия кодогенерации</param>
        /// <param name="FileName">Имя файла, в который нужно сгенерировать код</param>
        /// <param name="Items">Элементы генерации</param>
        void ExecuteAction(string ActionName, string FileName, ICollection<GenerationItem> Items);
    }
}
