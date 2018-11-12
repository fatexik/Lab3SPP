using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Permissions;

namespace AssemblyBrowser
{
    public class DataType
    {
        public string name { get; set; }
        public string TypeInfo { get; set; }
        public List<Field> fields;
        public List<Property> Properties;
        public List<Method> Methods;

        public DataType(TypeInfo typeInfo)
        {
            name = Attributes.GetAtributes(typeInfo) + typeInfo.Name;
            fields = new List<Field>();
            Properties = new List<Property>();
            Methods = new List<Method>();
            
            GetFields(typeInfo);
            GetMethods(typeInfo);
            GetProp(typeInfo);
        }

        private void GetProp(Type t)
        {
            var properties = t.GetProperties();

            foreach (var property in properties)
            {
                Properties.Add(new Property(property));
            }
        }
        
        private void GetMethods(Type t)
        {
            var methods = t.GetMethods();

            foreach (var method in methods)
            {
                if (!method.IsSpecialName)
                {
                    Methods.Add(new Method(method));
                }
            }
        }
        
        private void GetFields(Type t)
        {
            var fields = t.GetFields();

            foreach (var field in fields)
            {
                this.fields.Add(new Field(field));
            }
        }

        private void genTypeInfo()
        {
            TypeInfo = "Fields : ";
            foreach (var field in fields)
            {
                TypeInfo += field.type + " " + field.name;
            }

            TypeInfo += "Properties: ";
            foreach (var prop in Properties)
            {
                TypeInfo += prop.type + " " + prop.name;
            }

            TypeInfo += "Methods: ";
            foreach (var method in Methods)
            {
                TypeInfo += method.signature + method.name + " ";
            }
        }
    }
}