using System;
using System.Reflection;

namespace AssemblyBrowser
{
    public class AssemblyReader
    {

        public void reader(String path)
        {
            AssemblyResult assemblyResult = new AssemblyResult();
            Assembly assembly = Assembly.LoadFrom(path);
        }
        
    }
}