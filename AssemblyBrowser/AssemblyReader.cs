using System;
using System.Reflection;

namespace AssemblyBrowser
{
    public class AssemblyReader
    {

        public AssemblyResult read(String path)
        {
            AssemblyResult assemblyResult = new AssemblyResult();
            Assembly assembly = Assembly.LoadFrom(path);

            foreach (var type in assembly.DefinedTypes)
            {
                if (type.Namespace!=null && assemblyResult.NameSpaces.Find(x => x.name == type.Namespace) == null)
                {
                    assemblyResult.NameSpaces.Add(new NameSpaces(type.Namespace));
                }
            }

            foreach (var nameSpacese in assemblyResult.NameSpaces)
            {
                foreach (var type in assembly.DefinedTypes)
                {
                    if (type.Namespace == nameSpacese.name)
                    {
                        nameSpacese.DataTypes.Add(new DataType(type));
                    }
                }
            }

            return assemblyResult;
        }
        
    }
}