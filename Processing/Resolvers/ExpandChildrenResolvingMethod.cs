using System;
using System.Linq;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.Processing.Resolvers
{
    public class ExpandChildrenResolvingMethod : IResolvingMethod
    {
        private readonly ITemplateProcessor _templateProcessor;
        public ExpandChildrenResolvingMethod(ITemplateProcessor TemplateProcessor) { _templateProcessor = TemplateProcessor; }

        /// <summary>Разрешает значение свойства по его имени</summary>
        /// <param name="PropertyName">Название свойства</param>
        /// <param name="Arguments">Аргументы кодогенерации</param>
        public string Resolve(string PropertyName, GenerationArguments Arguments)
        {
            return
                string.Join(Environment.NewLine,
                            Arguments.Item.Children.Select(
                                subItem => _templateProcessor.ProcessInjectionTemplate(GetSubarguments(Arguments, subItem, PropertyName))));
        }

        private GenerationArguments GetSubarguments(GenerationArguments Arguments, GenerationItem SubItem, string TemplateName)
        {
            return new GenerationArguments(SubItem, Arguments.TemplatesDictionary[TemplateName], Arguments.TemplatesDictionary);
        }
    }
}
