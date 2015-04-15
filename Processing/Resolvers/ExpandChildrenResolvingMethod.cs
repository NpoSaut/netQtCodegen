using System;
using System.Collections.Generic;
using System.Linq;
using Codegen.ProjectEntities.Tasking;

namespace Codegen.Processing.Resolvers
{
    public class ExpandChildrenResolvingMethod : IResolvingMethod
    {
        private readonly ITemplateProcessor _templateProcessor;
        public ExpandChildrenResolvingMethod(ITemplateProcessor TemplateProcessor) { _templateProcessor = TemplateProcessor; }

        public string Resolve(string PropertyName, GenerationItem Item, string InjectionTemplate, IDictionary<string, string> InternalTemplates)
        {
            return
                string.Join(Environment.NewLine,
                            Item.Children.Select(
                                subItem => _templateProcessor.ProcessInjectionTemplate(subItem, InternalTemplates[PropertyName], InternalTemplates)));
        }
    }
}
