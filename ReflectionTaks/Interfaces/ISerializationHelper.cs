namespace ReflectionTaksExtension.Interfaces
{
    public interface ISerializationHelper
    {
        /// <summary>Извлекает значения полей объекта obj, отмеченных атрибутом CustomNameAttribute, 
        /// и формирует строку, содержащую пары имя-значение этих полей, разделенные пробелами.</summary>
        string ObjectToString(object obj);

        /// <summary>Позволяет работать с атрибутом CustomNameAttribute для записи 
        /// значение в свойство по имени его атрибута.</summary>
        void StringToObject(object obj, string data);
    }
}