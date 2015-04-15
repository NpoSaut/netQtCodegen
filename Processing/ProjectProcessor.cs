using Codegen.Injection;
using Codegen.Processing.Resolvers;
using Codegen.ProjectEntities;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.Processing
{
    public class ProjectProcessor : IProjectProcessor
    {
        public ProjectProcessor() { }

        /// <summary>Выполняет задания, назначенные в указанном проекте</summary>
        /// <param name="Project">Проект для обработки</param>
        public void Process(GenerationProject Project)
        {
            var injectionsManager = new InjectionsManager();
            var extensionsManager = new ReflectingExtensionsManager();

            foreach (GenerationTask task in Project.Tasks)
            {
                var propertiesResolverFactory = new PropertiesResolverFactory(task.Globals);
                IActionsManager actionsManager = new ProjectActionsManager(Project.Actions, injectionsManager,
                                                                           new TemplateProcessor(propertiesResolverFactory,
                                                                                                 extensionsManager));

                foreach (GenerationActionCalling actionCalling in task.CallingActions)
                    actionsManager.ExecuteAction(actionCalling.ActionName, actionCalling.TargetFileName, task.Items);
            }

            injectionsManager.Apply();
        }
    }
}
