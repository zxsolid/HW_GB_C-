namespace ReflectionTaksExtension.AttributeExtension;

[AttributeUsage(AttributeTargets.Field)]
public class CustomNameAttribute : Attribute
{
    public string CustomFieldName { get; }

    public CustomNameAttribute(string customFieldName)
    {
        CustomFieldName = customFieldName;
    }
}