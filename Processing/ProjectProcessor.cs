using Codegen.Injection;
using Codegen.ProjectEntities;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.Processing
{
    public class ProjectProcessor : IProjectProcessor
    {
        /// <summary>Выполняет задания, назначенные в указанном проекте</summary>
        /// <param name="Project">Проект для обработки</param>
        public void Process(GenerationProject Project)
        {
            var injectionsManager = new InjectionsManager();
            var extensionsManager = new ReflectingExtensionsManager();

            foreach (GenerationTask task in Project.Tasks)
            {
                IActionsManager actionsManager = new ProjectActionsManager(Project.Actions, injectionsManager,
                                                                           new TemplateProcessor(new PropertiesResolver(task.Globals),
                                                                                                 extensionsManager));

                foreach (GenerationActionCalling actionCalling in task.CallingActions)
                    actionsManager.ExecuteAction(actionCalling.ActionName, actionCalling.TargetFileName, task.Items);
            }

            injectionsManager.Apply();
        }
    }
}
