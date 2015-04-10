using QmlObjectPropertiesCodeGenerator.ProjectEntities;

namespace QmlObjectPropertiesCodeGenerator.ProjectLoaders
{
    /// <summary>Загрузчик проекта</summary>
    public interface IProjectLoader
    {
        /// <summary>Загружает проект кодогенерации</summary>
        GenerationProject Load();
    }
}
