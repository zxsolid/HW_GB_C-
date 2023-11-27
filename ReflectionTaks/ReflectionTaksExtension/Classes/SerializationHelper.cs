using ReflectionTaksExtension.AttributeExtension;
using ReflectionTaksExtension.Interfaces;
using System.Reflection;
using System.Text;

namespace ReflectionTaksExtension.Classes
{
    public class SerializationHelper : ISerializationHelper
    {
        public string ObjectToString(object obj)
        {
            Type objectType = obj.GetType();
            FieldInfo[] fields = objectType.GetFields();

            var resultBuilder = new StringBuilder();

            foreach (FieldInfo field in fields)
            {
                // Проверяеем, есть ли у текущего поля атрибут
                CustomNameAttribute? customNameAttribute =
                    Attribute.GetCustomAttribute(field, typeof(CustomNameAttribute)) as CustomNameAttribute;

                if (customNameAttribute != null)
                {
                    string fieldName = customNameAttribute.CustomFieldName;
                    object? fieldValue = field.GetValue(obj);
                    resultBuilder.Append(fieldName);
                    resultBuilder.Append(":");
                    resultBuilder.Append(fieldValue?.ToString());
                    resultBuilder.Append(" ");
                }
            }

            return resultBuilder.ToString().Trim();
        }

        public void StringToObject(object obj, string data)
        {
            Type objectType = obj.GetType();
            FieldInfo[] fields = objectType.GetFields();

            //Разделение строки на пары ключ-значение
            string[] keyValuePairs = data.Split(' ');

            foreach (string keyValuePair in keyValuePairs)
            {
                // Разделение пары ключ-значение на отдельные част
                string[] parts = keyValuePair.Split(':');
                string propertyName = parts[0];
                string propertyValue = parts[1];

                FieldInfo matchingField = null;

                // Поиск поля совпадающего с указанным именем свойства
                foreach (FieldInfo field in fields)
                {
                    CustomNameAttribute? customNameAttribute =
                        Attribute.GetCustomAttribute(field, typeof(CustomNameAttribute)) as CustomNameAttribute;

                    if (customNameAttribute != null && customNameAttribute.CustomFieldName == propertyName)
                    {
                        // Найдено совпадающее поле
                        matchingField = field;
                        break;
                    }
                }

                if (matchingField != null)
                {
                    object parsedValue = null;

                    // Преобразование значения свойства в правильный тип
                    Type fieldType = matchingField.FieldType;

                    //Взаивисимости от типа парсим свойство
                    if (fieldType == typeof(int))
                        parsedValue = int.Parse(propertyValue);
                    else if (fieldType == typeof(string))
                        parsedValue = propertyValue;

                    // TODO Добавляем условия преобразования типов

                    // Установка значения поля объекта
                    if (parsedValue != null)
                        matchingField.SetValue(obj, parsedValue);

                }
            }
        }
    }
}