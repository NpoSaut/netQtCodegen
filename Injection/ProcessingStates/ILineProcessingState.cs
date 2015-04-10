namespace QmlObjectPropertiesCodeGenerator.Injection.ProcessingStates
{
    internal interface ILineProcessingState
    {
        /// <summary>Обрабатывает указанную линию и возвращает актуальное состояние для обработки следующей линии</summary>
        /// <param name="line">Обрабатываемая линия</param>
        ILineProcessingState ProcessLine(string line);
    }
}
