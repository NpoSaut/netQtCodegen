using System.Collections.Generic;

namespace Codegen.ProjectEntities.Actions
{
    /// <summary>Действие кодогенерации</summary>
    public class GenerationAction
    {
        public GenerationAction(string Name, ICollection<Injection> Injections, IDictionary<string, string> Templates)
        {
            this.Templates = Templates;
            this.Name = Name;
            this.Injections = Injections;
        }

        /// <summary>Имя действия</summary>
        public string Name { get; private set; }

        /// <summary>Сипсок инъекций для этого действия</summary>
        public ICollection<Injection> Injections { get; private set; }

        /// <summary>Шаблоны для внутренних инъекций</summary>
        public IDictionary<string, string> Templates { get; private set; }

        public override string ToString() { return string.Format("Action \"{0}\"", Name); }
    }
}
