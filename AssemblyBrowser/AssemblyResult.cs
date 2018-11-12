using System.Collections.Generic;
using System.Reflection;

namespace AssemblyBrowser
{
    public class AssemblyResult
    {
        public List<NameSpaces> NameSpaceses { set; get; }

        public AssemblyResult()
        {
            NameSpaceses = new List<NameSpaces>();
        }
    }
}