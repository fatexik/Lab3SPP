using System.Reflection;

namespace AssemblyBrowser
{
    public class Property
    {
        public string name;
        public string type;

        public Property(PropertyInfo propertyInfo)
        {
            name = propertyInfo.Name;
            type = propertyInfo.PropertyType.Name;
        }
    }
}