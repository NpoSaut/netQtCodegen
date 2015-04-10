using QmlObjectPropertiesCodeGenerator.ProjectEntities;
using QmlObjectPropertiesCodeGenerator.ProjectEntities.Tasking;

namespace QmlObjectPropertiesCodeGenerator.Processing
{
    public class ProjectProcessor : IProjectProcessor
    {
        /// <summary>Выполняет задания, назначенные в указанном проекте</summary>
        /// <param name="Project">Проект для обработки</param>
        public void Process(GenerationProject Project)
        {
            IActionsManager actionsManager = new ProjectActionsManager(Project.Actions);
            foreach (GenerationTask task in Project.Tasks)
            {
                foreach (GenerationActionCalling actionCalling in task.CallingActions)
                    actionsManager.ExecuteAction(actionCalling.ActionName, actionCalling.TargetFileName, task.Items);
            }
        }
    }
}
