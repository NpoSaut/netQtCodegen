using System.Collections.Generic;

namespace Codegen.ProjectEntities.Actions
{
    /// <summary>Шаблон вставки</summary>
    /// <remarks>Шаблон того, что будет вставляться в файл в некотором действии по кодогенерации</remarks>
    public class InjectionTemplate
    {
        public InjectionTemplate(string Anchor, string Template, IDictionary<string, string> InternalTemplates, string InjectionTargetFilter)
        {
            this.InjectionTargetFilter = InjectionTargetFilter;
            this.InternalTemplates = InternalTemplates;
            this.Anchor = Anchor;
            this.Template = Template;
        }

        /// <summary>Якорь инжекции</summary>
        public string Anchor { get; private set; }

        /// <summary>Шаблон инжекции</summary>
        public string Template { get; private set; }

        /// <summary>Шаблоны для внутренних инъекций</summary>
        public IDictionary<string, string> InternalTemplates { get; private set; }

        /// <summary>Фильтр названий элементов, для которых нужно выполнять инъекции</summary>
        public string InjectionTargetFilter { get; private set; }

        public override string ToString()
        {
            return string.Format("Injection for \"{0}\"{1}", Anchor,
                                 string.IsNullOrWhiteSpace(InjectionTargetFilter) ? string.Empty : string.Format(" (filter: {0})", InjectionTargetFilter));
        }
    }
}
