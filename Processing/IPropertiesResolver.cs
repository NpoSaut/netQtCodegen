using System.Collections.Generic;

namespace QmlObjectPropertiesCodeGenerator.Processing
{
    /// <summary>Инструмент, разрешающий значения свойства по его имени</summary>
    public interface IPropertiesResolver
    {
        /// <summary>Вычисляет значение свойства по его имени</summary>
        /// <param name="PropertyName">Имя свойства</param>
        /// <param name="PropertyNamespace">Пространство имён свойства (задаётся каким-нибудь символом вроде '#')</param>
        /// <param name="LocalProperties">Словарь локальных свойств</param>
        string ResolvePropertyValue(string PropertyName, string PropertyNamespace, IDictionary<string, string> LocalProperties);
    }
}
