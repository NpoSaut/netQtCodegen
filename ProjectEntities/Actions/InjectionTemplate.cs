﻿namespace Codegen.ProjectEntities.Actions
{
    /// <summary>Шаблон вставки</summary>
    /// <remarks>Шаблон того, что будет вставляться в файл в некотором действии по кодогенерации</remarks>
    public class InjectionTemplate
    {
        public InjectionTemplate(string Anchor, string Template)
        {
            this.Anchor = Anchor;
            this.Template = Template;
        }

        /// <summary>Якорь инжекции</summary>
        public string Anchor { get; private set; }

        /// <summary>Шаблон инжекции</summary>
        public string Template { get; private set; }

        public override string ToString() { return string.Format("Injection for \"{0}\"", Anchor); }
    }
}
