using System;
using System.Linq;
using Codegen.Annotations;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.Processing.Resolvers.Functions
{
    public class ExpandFunction : ResolvingFunctionBase
    {
        private readonly ITemplateProcessor _templateProcessor;
        public ExpandFunction(ITemplateProcessor TemplateProcessor) { _templateProcessor = TemplateProcessor; }

        [UsedImplicitly]
        public string Execute(GenerationArguments Arguments, string TemplateName)
        {
            return
                string.Join(Environment.NewLine,
                            Arguments.Item.Children
                            .Select(subItem => _templateProcessor.ProcessInjectionTemplate(GetSubarguments(Arguments, subItem, TemplateName))));
        }

        [UsedImplicitly]
        public string Execute(GenerationArguments Arguments, string ItemName, string TemplateName)
        {
            return
                string.Join(Environment.NewLine,
                            Arguments.Item.Children
                            .Where(c => c.Name == ItemName)
                            .Select(subItem => _templateProcessor.ProcessInjectionTemplate(GetSubarguments(Arguments, subItem, TemplateName))));
        }

        private GenerationArguments GetSubarguments(GenerationArguments Arguments, GenerationItem SubItem, string TemplateName)
        {
            return new GenerationArguments(SubItem, Arguments.TemplatesDictionary[TemplateName], Arguments.TemplatesDictionary, Arguments.Item);
        }
    }
}
