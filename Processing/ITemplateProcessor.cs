namespace Codegen.Processing
{
    /// <summary>Обработчик шаблонов кодогенерации</summary>
    public interface ITemplateProcessor
    {
        /// <summary>Обрабатывает шаблон и строит блок кода на его основе</summary>
        /// <param name="Arguments">Аргументы генерации</param>
        string ProcessInjectionTemplate(GenerationArguments Arguments);
    }
}
