﻿using QmlObjectPropertiesCodeGenerator.ProjectEntities;

namespace QmlObjectPropertiesCodeGenerator.Processing
{
    /// <summary>Обработчик проекта</summary>
    public interface IProjectProcessor
    {
        /// <summary>Выполняет задания, назначенные в указанном проекте</summary>
        /// <param name="Project">Проект для обработки</param>
        void Process(GenerationProject Project);
    }
}
