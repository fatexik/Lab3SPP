using System;
using System.Reflection;

namespace AssemblyBrowser
{
    public class Field
    {
        public string name;
        public string type;

        public Field(FieldInfo fieldInfo)
        {
            name = fieldInfo.Name + " ";
            type = Attributes.GetModifiers(fieldInfo.GetType());
            if (fieldInfo.FieldType.IsGenericType)
            {
                type += fieldInfo.FieldType.Name + " <" + GetGenericType(fieldInfo.FieldType.GenericTypeArguments) + "> ";
            }
            else
            {
                type += " " + fieldInfo.FieldType.Name + " ";
            }
        }
        
        private string GetGenericType(Type[] types)
        {
            string result = "";
            foreach(Type genericType in types)
            {
                if (types.GetType().IsGenericType)
                    result += " <" + GetGenericType(genericType.GetType().GenericTypeArguments) + "> ";
                else
                    result +=" "+genericType.Name + " ";
            }

            return result;
        }
    }
    
    
}