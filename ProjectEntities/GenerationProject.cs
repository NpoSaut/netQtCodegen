using System.Collections.Generic;
using Codegen.ProjectEntities.Actions;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.ProjectEntities
{
    /// <summary>Проект кодогенерации</summary>
    /// <remarks>Основной класс, согласно которому будет произведена работа по кодогенерации</remarks>
    public class GenerationProject
    {
        public GenerationProject(ICollection<GenerationTask> Tasks, ICollection<GenerationAction> Actions)
        {
            this.Tasks = Tasks;
            this.Actions = Actions;
        }

        /// <summary>Задачи генерации</summary>
        public ICollection<GenerationTask> Tasks { get; private set; }

        /// <summary>Действия генерации</summary>
        /// <remarks>Варианты того, что можно сгенерировать</remarks>
        public ICollection<GenerationAction> Actions { get; private set; }
    }
}
