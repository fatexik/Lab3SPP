using System.Collections.Generic;

namespace AssemblyBrowser
{
    public class NameSpaces
    {
        public string name { set; get; }
        public List<DataType> DataTypes { set; get; }

        public NameSpaces(string name)
        {
            this.name = name;
            DataTypes = new List<DataType>();
        }
    }
}