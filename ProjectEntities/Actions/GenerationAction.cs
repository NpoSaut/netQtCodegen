using System.Collections.Generic;

namespace QmlObjectPropertiesCodeGenerator.ProjectEntities.Actions
{
    /// <summary>Действие кодогенерации</summary>
    public class GenerationAction
    {
        public GenerationAction(string Name, ICollection<InjectionTemplate> Injections)
        {
            this.Name = Name;
            this.Injections = Injections;
        }

        /// <summary>Имя действия</summary>
        public string Name { get; private set; }

        /// <summary>Сипсок инъекций для этого действия</summary>
        public ICollection<InjectionTemplate> Injections { get; private set; }

        public override string ToString() { return string.Format("Action \"{0}\"", Name); }
    }
}
