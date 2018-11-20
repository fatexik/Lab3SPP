using System.Collections.Generic;
using System.Reflection;

namespace AssemblyBrowser
{
    public class AssemblyResult
    {
        public List<NameSpaces> NameSpaces { set; get; }

        public AssemblyResult()
        {
            NameSpaces = new List<NameSpaces>();
        }
    }
}