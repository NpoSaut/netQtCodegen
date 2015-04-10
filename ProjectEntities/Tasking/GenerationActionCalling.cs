namespace QmlObjectPropertiesCodeGenerator.ProjectEntities.Tasking
{
    /// <summary>Вызов действия кодогенерации</summary>
    public class GenerationActionCalling
    {
        /// <summary>Инициализирует новый экземпляр класса <see cref="T:System.Object" />.</summary>
        public GenerationActionCalling(string ActionName, string TargetFileName)
        {
            this.ActionName = ActionName;
            this.TargetFileName = TargetFileName;
        }

        /// <summary>Название вызываемого действия</summary>
        public string ActionName { get; private set; }

        /// <summary>Имя файла, к которому должно быть применено действие</summary>
        public string TargetFileName { get; private set; }

        public override string ToString() { return string.Format("Calling {0} -> {1}", ActionName, TargetFileName); }
    }
}
