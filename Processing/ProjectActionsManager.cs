using System.Collections.Generic;
using System.Linq;
using Codegen.Injection;
using Codegen.ProjectEntities.Actions;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.Processing
{
    public class ProjectActionsManager : IActionsManager
    {
        private readonly Dictionary<string, GenerationAction> _actions;
        private readonly IInjectionsManager _injectionsManager;
        private readonly ITemplateProcessor _templateProcessor;

        public ProjectActionsManager(ICollection<GenerationAction> Actions, IInjectionsManager InjectionsManager, ITemplateProcessor TemplateProcessor)
        {
            _injectionsManager = InjectionsManager;
            _templateProcessor = TemplateProcessor;
            _actions = Actions.ToDictionary(a => a.Name);
        }

        /// <summary>Запускает действие по кодогенерации</summary>
        /// <param name="ActionName">Название действия кодогенерации</param>
        /// <param name="FileName">Имя файла, в который нужно сгенерировать код</param>
        /// <param name="Items">Элементы генерации</param>
        public void ExecuteAction(string ActionName, string FileName, ICollection<GenerationItem> Items)
        {
            GenerationAction action = _actions[ActionName];
            foreach (InjectionTemplate injection in action.Injections)
            {
                foreach (GenerationItem item in Items)
                {
                    string code = _templateProcessor.ProcessInjectionTemplate(new GenerationArguments(item, injection.Template, injection.InternalTemplates));
                    _injectionsManager.Inject(FileName, injection.Anchor, code);
                }
            }
        }
    }
}
